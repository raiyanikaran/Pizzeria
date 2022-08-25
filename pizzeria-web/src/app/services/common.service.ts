import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { HttpService } from './http.service';
import { AllItems } from '../models/AllItems';
import { Order, OrderUi } from '../models/Order';
import { User } from '../models/User';
import { Observable } from 'rxjs';
import { Cheese } from '../models/Cheese';
import { Pizza, PizzaUi } from '../models/Pizza';
import { CartItem } from '../models/CartItem';
import { NonPizzaItem, NonPizzaItemUi } from '../models/NonPizzaItem';
import { Ingredient } from '../models/Ingredient';
import { Topping } from '../models/Topping';
import { CrustSize } from '../models/CrustSize';
import { CrustSauce } from '../models/CrustSauce';

@Injectable({
  providedIn: 'root'
})
export class CommonService extends HttpService {

  allItems: AllItems = new AllItems(); 
  allUsers: User[] = [];
  allPizzaItems: PizzaUi[] = [];
  allNonPizzaItems: NonPizzaItemUi[] = [];
  allIngrediants: Ingredient[] = [];
  allToppings: Topping[] = [];
  allCrustSizes: CrustSize[] = [];
  allCrustSauces: CrustSauce[] = [];
  allCheese: Cheese[] = [];
  allOrders: OrderUi[] = [];
  cartItems: CartItem = new CartItem();
  currentUserId: number = 0;

  constructor(protected httpClient: HttpClient) {
    super(httpClient);
  }

  createOrder(body: Order): Observable<Order> {
    return this.post('orders', body);
  }

  getAllItems() {
    this.get('items', null).subscribe((data: AllItems) => {
      let allItems = JSON.parse(JSON.stringify(data)) as AllItems;
      this.allItems = allItems;
      this.allPizzaItems = allItems.Pizzas.map(m => {
        let pizza: Pizza = new Pizza();
        let pizzaUi = Object.assign(pizza, m);
        return pizzaUi.getPizza(JSON.parse(JSON.stringify(data)) as AllItems);
      });
      this.allNonPizzaItems = allItems.NonPizzaItems.map(m => {
        let nonPizzaItem: NonPizzaItem = new NonPizzaItem();
        let nonPizzaItemUi = Object.assign(nonPizzaItem, m);
        return nonPizzaItemUi.getNonPizzaItem(JSON.parse(JSON.stringify(data)) as AllItems);
      });
      this.allCheese = allItems.Cheese;
      this.allCrustSauces = allItems.CrustSauces;
      this.allCrustSizes = allItems.CrustSizes;
      this.allIngrediants = allItems.Ingredients;
      this.allToppings = allItems.Toppings;
    }, err => {
      console.log(err);
    });
  }

  getOrders(userId: number) {
    this.allOrders = [];
    this.get('orders/' + userId, null).subscribe(data => {
      if (data?.length) {
        this.setAllOrders(data);
      }
    }, err => {
      console.log(err);
    });
  }

  getUsers() {
    this.get('users', null).subscribe(data => {
      this.allUsers = data;
    }, err => {
      console.log(err);
    });
  }

  setAllOrders(orders: Order[]= []){
    let allOrders = orders.map((m: Order) => {
      let order: Order = new Order();
      let orderUiObj = Object.assign(order, m);
      let orderUi: OrderUi = orderUiObj.getOrder(this.allItems);
      orderUi.UserName = this.allUsers.find(k => k.Id == m.UserId)?.Name;
      return orderUi;
    });
    this.allOrders = allOrders;
  }

}
