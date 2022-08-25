import { AllItems } from "./AllItems";
import { NonPizzaItem, NonPizzaItemUi } from "./NonPizzaItem";
import { Pizza, PizzaUi } from "./Pizza";

export class Order {
    Id: number | undefined;
    UserId: number | undefined;
    Address: string | undefined;
    TotalAmmount: number | undefined;
    Pizzas: Pizza[] = [];
    NonPizzaItems: NonPizzaItem[] = [];
    OrderCreationTime: Date = new Date();

    getOrder(allItems: AllItems): OrderUi {
        let order = new OrderUi();
        order.Id = this.Id ?? (Math.floor(Math.random() * 100) + Date.now());
        order.Pizzas = this.Pizzas ? this.Pizzas.map(m => { 
            let pizza = Object.assign(new Pizza(), m);
            return pizza.getPizza(allItems);
        }) : [];
        order.NonPizzaItems = allItems.NonPizzaItems ? this.NonPizzaItems.map(m => { 
            let nonPizza = Object.assign(new NonPizzaItem(), m);
            return nonPizza.getNonPizzaItem(allItems);
        }) : [];
        order.OrderCreationTime = this.OrderCreationTime;
        let totalPrice = 0.00;
        order.Pizzas.forEach(pizza => {
            totalPrice += pizza.Quantity ? pizza.Price * pizza.Quantity : pizza.Price;
        });
        order.NonPizzaItems.forEach(nonPizzaItem => {
            if(nonPizzaItem.Quantity)
            totalPrice += nonPizzaItem.Price * nonPizzaItem.Quantity;
        });
        order.TotalAmmount = totalPrice;
        return order;
    }
}

export class OrderUi {
    Id: number | undefined;
    UserName: string | undefined;
    Address: string | undefined;
    TotalAmmount: number | undefined;
    Pizzas: PizzaUi[] = [];
    NonPizzaItems: NonPizzaItemUi[] = [];
    OrderCreationTime: Date = new Date();
}