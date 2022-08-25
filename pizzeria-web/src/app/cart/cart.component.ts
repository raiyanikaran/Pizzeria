import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTabChangeEvent } from '@angular/material/tabs';
import { CartItem } from '../models/CartItem';
import { NonPizzaItem, NonPizzaItemUi } from '../models/NonPizzaItem';
import { Order } from '../models/Order';
import { Pizza, PizzaUi } from '../models/Pizza';
import { CommonService } from '../services/common.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss']
})
export class CartComponent implements OnInit {
  
  showRemoveButton = true;
  
  constructor(public commonService: CommonService) {
  }

  ngOnInit(): void {
  }

  tabChange(event: MatTabChangeEvent) {

    if (event.index == 1){
      this.showRemoveButton = false;
      this.commonService.getOrders(this.commonService.currentUserId);
    } else this.showRemoveButton = true;
  }

  removeCartItem(item: PizzaUi | NonPizzaItemUi) {
    let cartItems = (item instanceof PizzaUi ? this.commonService.cartItems.Pizzas : this.commonService.cartItems.NonPizzaItems) as any;
    let matchItem = cartItems.find((k: any) => k.Id == item.Id);
    if (matchItem?.Quantity && matchItem.Quantity > 1) {
      matchItem.Quantity--;
    } else {
      this.commonService.cartItems[item instanceof PizzaUi ? 'Pizzas' : 'NonPizzaItems'] = cartItems.filter((k: any) => k.Id != item.Id);
      this.commonService.cartItems.updateGrandTotal();
    }
  }

  placeOrder() {
    let cartItem = this.commonService.cartItems;
    if(cartItem.TotalAmmount == 0) return;
    let order = new Order();
    order.Id = (Math.floor(Math.random() * 6) + 1 + Date.now());
    let userDetails = this.commonService.allUsers.find(k => k.Id == this.commonService.currentUserId);
    order.UserId = userDetails?.Id;
    order.Address = userDetails?.Address;
    let pizzas: Pizza[] = [];
    cartItem.Pizzas.forEach(piz => {
      let pizza = new Pizza();
      pizza.Id = piz.Id;
      pizza.Name = piz.Name;
      pizza.Image = piz.Image;
      pizza.Quantity = piz.Quantity;
      pizza.Price = piz.Price;
      pizza.SizeId = piz.Size ? piz.Size.Id : 'SML';
      pizza.ToppingIDs = piz.Toppings.filter(k => k.IsAdded).map(k => k.Id);
      pizza.CheeseIDs = piz.Cheeses.filter(k => k.IsAdded).map(k => k.Id);
      pizza.CrustSauceIDs = piz.CrustSauces.filter(k => k.IsAdded).map(k => k.Id);
      pizza.IngredientIDs = piz.Ingredients.filter(k => k.IsAdded).map(k => k.Id);
      pizzas.push(pizza);
    });
    order.Pizzas = pizzas;

    let nonPizzas: NonPizzaItem[] = [];
    cartItem.NonPizzaItems.forEach(nonPiz => {
      let nonPizzaItem = new NonPizzaItem();
      nonPizzaItem.Id = nonPiz.Id;
      nonPizzaItem.Name = nonPiz.Name;
      nonPizzaItem.Quantity = nonPiz.Quantity;
      nonPizzaItem.Price = nonPiz.Price;
      nonPizzaItem.IngredientIDs = nonPiz.Ingredients.filter(k => k.IsAdded).map(k => k.Id);
      nonPizzas.push(nonPizzaItem);
    });
    order.NonPizzaItems = nonPizzas;
    order.TotalAmmount = cartItem.TotalAmmount;
    order.OrderCreationTime = new Date();

    this.commonService.createOrder(order).subscribe((data: Order) => {
      if(data){
        this.commonService.getOrders(this.commonService.currentUserId);
        this.commonService.cartItems = new CartItem();
      }
    },
    err =>{
      alert('Order creation failed!');
    });
  }

}
