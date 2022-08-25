import { AllItems } from "./AllItems";
import { Cheese } from "./Cheese";
import { CrustSauce } from "./CrustSauce";
import { CrustSize } from "./CrustSize";
import { Ingredient } from "./Ingredient";
import { Topping } from "./Topping";

export class Pizza {
    Id: number = 0;
    Name: string | undefined;
    Price = 0.00;
    Image: string | undefined;
    IngredientIDs: string[] = [];
    ToppingIDs: string[] = [];
    CheeseIDs: string[] = [];
    CrustSauceIDs: string[] = [];
    SizeId: string = 'SML';
    Quantity = 0;
    IsCustomPizza = false;

    getPizza(allItems: AllItems): PizzaUi {
        let pizza : PizzaUi = new PizzaUi();
        let totalPrice = 0;
        pizza.Id = this.Id ? this.Id : (Math.floor(Math.random() * 100) + Date.now());
        pizza.Name = this.Name ? (this.IsCustomPizza ? `Custom ${this.Name}` : this.Name) : 'Custom Pizza';
        pizza.Image = this.Image;
        pizza.IsCustomPizza = this.IsCustomPizza;
        pizza.Cheeses = allItems.Cheese.map(k => {
            if(this.CheeseIDs.includes(k.Id)) {
                k.IsAdded = true;
                totalPrice += k.Price;
            } else k.IsAdded = false;
            return k;
        });
        pizza.Ingredients = allItems.Ingredients.map(k => {
            if(this.IngredientIDs.includes(k.Id)) {
                k.IsAdded = true;
                totalPrice += k.Price;
            } else k.IsAdded = false;
            return k;
        });
        pizza.Toppings = allItems.Toppings.map(k => {
            if(this.ToppingIDs.includes(k.Id)) {
                k.IsAdded = true;
                totalPrice += k.Price;
            } else k.IsAdded = false;
            return k;
        });
        pizza.CrustSauces = allItems.CrustSauces.map(k => {
            if(this.CrustSauceIDs.includes(k.Id)) {
                k.IsAdded = true;
                totalPrice += k.Price;
            } else k.IsAdded = false;
            return k;
        });
        pizza.Size = allItems.CrustSizes.find(k => k.Id == this.SizeId);
        if(pizza.Size?.Price) totalPrice += pizza.Size.Price;
        pizza.Quantity = this.Quantity;
        pizza.Price = totalPrice;
        return pizza;
    }
}

export class PizzaUi {
    Id: number = 0;
    Name: string = '';
    Price = 0.00;
    Image: string | undefined;
    Ingredients: Ingredient[] = [];
    Toppings: Topping[] = [];
    Cheeses: Cheese[] = [];
    CrustSauces: CrustSauce[] = [];
    Size: CrustSize | undefined;
    Quantity: number = 0;
    IsCustomPizza = false;

    updatePrice() {
        let totalPrice = 0;
        this.Ingredients.filter(k => { if(k.IsAdded) totalPrice += k.Price});
        this.Cheeses.filter(k => { if(k.IsAdded) totalPrice += k.Price});
        this.Toppings.filter(k => { if(k.IsAdded) totalPrice += k.Price});
        this.CrustSauces.filter(k => { if(k.IsAdded) totalPrice += k.Price});
        if(this.Size?.Price) totalPrice += this.Size.Price;
        this.Price = totalPrice;
    }
}