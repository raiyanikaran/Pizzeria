import { Component, EventEmitter, Output } from '@angular/core';
import { NonPizzaItemUi } from '../models/NonPizzaItem';
import { Pizza, PizzaUi } from '../models/Pizza';
import { CommonService } from '../services/common.service';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss']
})
export class MenuComponent {

  @Output() openDialog = new EventEmitter<PizzaUi>();
  @Output() addToCart = new EventEmitter<NonPizzaItemUi>();

  constructor(public commonService: CommonService) { }

  openPizzaBuilderDialog(pizza: PizzaUi = new PizzaUi()) {
    if(!pizza.Id){
      let piz = new Pizza();
      pizza = piz.getPizza(JSON.parse(JSON.stringify(this.commonService.allItems)));
    }
    this.openDialog.emit(pizza);
  }

  addNonPizzaItemToCart(item: NonPizzaItemUi) {
    this.addToCart.emit(item);
  }

}
