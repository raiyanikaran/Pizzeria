import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { BuildPizzaComponent } from '../build-pizza/build-pizza.component';
import { PizzaUi } from '../models/Pizza';
import { CommonService } from '../services/common.service';
import * as _ from 'lodash'; 
import { OrderUi } from '../models/Order';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent  {

  OrderItems: OrderUi[] = [];

  constructor(public commonService: CommonService, public dialog: MatDialog) {
    this.commonService.getUsers();
    this.commonService.getAllItems();
   }

  addToCart(item: any) {
    let isPizza = item instanceof PizzaUi;
    let cartItems: any = (isPizza ? this.commonService.cartItems.Pizzas : this.commonService.cartItems.NonPizzaItems);
    let mathcItem = cartItems.find((k: any) =>
      (!isPizza && k.Id == item.Id) ||
      (isPizza && JSON.stringify(k.Cheeses) == JSON.stringify(item.Cheeses) && JSON.stringify(k.CrustSauces) == JSON.stringify(item.CrustSauces) &&
        JSON.stringify(k.Ingredients) == JSON.stringify(item.Ingredients) && JSON.stringify(k.Size) == JSON.stringify(item.Size) &&
        JSON.stringify(k.Toppings) == JSON.stringify(item.Toppings) && JSON.stringify(k.CrustSauces) == JSON.stringify(item.CrustSauces))
    );

    if (mathcItem) mathcItem.Quantity++;
    else {
      item.Id = (Math.floor(Math.random() * 100) + Date.now());
      item.Quantity++;
      cartItems.push(item);
    }
    this.commonService.cartItems.updateGrandTotal();
  }

  openBuildPizzaDialog(pizza: PizzaUi = new PizzaUi()) {
    const dialogRef = this.dialog.open(BuildPizzaComponent, {
      // width: '250px',
      data: _.cloneDeep(pizza)
    });

    dialogRef.afterClosed().subscribe((pizza: PizzaUi) => {
      console.log('The dialog was closed');
      if(pizza) this.addToCart(pizza);
    });
  }

}
