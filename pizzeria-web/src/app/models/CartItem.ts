import { NonPizzaItem, NonPizzaItemUi } from "./NonPizzaItem";
import { PizzaUi } from "./Pizza";

export class CartItem {
    Pizzas: PizzaUi[] = [];
    NonPizzaItems: NonPizzaItemUi[] = [];
    TotalAmmount: number = 0.00;

    updateGrandTotal() {
        let totalAmmount = 0;
        this.Pizzas.forEach(pizza => {
            totalAmmount += (pizza.Quantity * pizza.Price);
        });
        this.NonPizzaItems.forEach(nonPizzaItem => {
            totalAmmount += (nonPizzaItem.Quantity * nonPizzaItem.Price);
        });
        this.TotalAmmount = totalAmmount;
    }
}