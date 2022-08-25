import { AllItems } from "./AllItems";
import { Ingredient } from "./Ingredient";

export class NonPizzaItem {
    Id: number = 0;
    Name: string | undefined;
    Image: string | undefined;
    Price: number = 0;
    IngredientIDs: string[] = [];
    Quantity: number = 0;

    getNonPizzaItem(allItems: AllItems): NonPizzaItemUi {
        let nonPizzaItem : NonPizzaItemUi = new NonPizzaItemUi();
        nonPizzaItem.Id = this.Id ?? (Math.floor(Math.random() * 100) + Date.now());
        nonPizzaItem.Name = this.Name;
        nonPizzaItem.Price = this.Price;
        nonPizzaItem.Image = this.Image;
        nonPizzaItem.Quantity = this.Quantity;
        nonPizzaItem.Ingredients = allItems.Ingredients.map(k => {
            if(this.IngredientIDs.includes(k.Id)) {
                k.IsAdded = true;
            }
            return k;
        });
        return nonPizzaItem;
    }
}

export class NonPizzaItemUi {
    Id: number = 0;
    Name: string | undefined;
    Image: string | undefined;
    Price: number = 0;
    Ingredients: Ingredient[] = [];
    Quantity: number = 0;
}