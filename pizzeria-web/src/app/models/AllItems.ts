import { Cheese } from "./Cheese";
import { CrustSauce } from "./CrustSauce";
import { CrustSize } from "./CrustSize";
import { Ingredient } from "./Ingredient";
import { NonPizzaItem } from "./NonPizzaItem";
import { Pizza, PizzaUi } from "./Pizza";
import { Topping } from "./Topping";

export class AllItems {
    Pizzas: Pizza[] = [];
    NonPizzaItems: NonPizzaItem[] = [];
    Ingredients: Ingredient[] = [];
    Cheese: Cheese[] = [];
    CrustSauces: CrustSauce[] = [];
    CrustSizes: CrustSize[] = [];
    Toppings: Topping[] = [];
}

export class AllSelectedItems {
    Pizzas: PizzaUi[] = [];
    NonPizzaItems: NonPizzaItem[] = [];
    TotalAmmount: number = 0.00;
}