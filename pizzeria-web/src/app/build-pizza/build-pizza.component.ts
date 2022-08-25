import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { CrustSize } from '../models/CrustSize';
import { PizzaUi } from '../models/Pizza';
import { CommonService } from '../services/common.service';

@Component({
  selector: 'app-build-pizza',
  templateUrl: './build-pizza.component.html',
  styleUrls: ['./build-pizza.component.scss']
})
export class BuildPizzaComponent implements OnInit {

  pizza: PizzaUi = new PizzaUi();

  constructor(public dialogRef: MatDialogRef<BuildPizzaComponent>,
    @Inject(MAT_DIALOG_DATA) public data: PizzaUi, public commonService: CommonService) {
    this.pizza = <PizzaUi>data;
  }

  ngOnInit(): void {
  }

  onClose(): void {
    this.dialogRef.close();
  }

  onAddToCart() {
    if(this.pizza.Cheeses.some(k => k.IsAdded) && this.pizza.Ingredients.some(k => k.IsAdded) 
      && this.pizza.CrustSauces.some(k => k.IsAdded)) {
      this.dialogRef.close(this.pizza);
    } else {
      window.alert('Please select atleast one option in each category!')
    } 
  }

  changeCrustSize(size: CrustSize) {
    this.pizza.Size = size;
    this.updatePrice();
  }

  onChangeOption(option: any = null) {
    if (option) {
      option.IsAdded = !option.IsAdded;
      this.updatePrice();
    }
  }

  updatePrice() {
    (<PizzaUi>this.pizza).updatePrice();
  }

}
