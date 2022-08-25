import { ComponentFixture, TestBed } from '@angular/core/testing';
import { NonPizzaItemUi } from '../models/NonPizzaItem';

import { CartComponent } from './cart.component';

describe('CartComponent', () => {
  let component: CartComponent;
  let fixture: ComponentFixture<CartComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CartComponent ]
    })
    .compileComponents().then(() => {
      fixture = TestBed.createComponent(CartComponent);
      component = fixture.componentInstance; // ContactComponent test instance
    });
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should remove cart item', () => {
    expect(component.removeCartItem(new NonPizzaItemUi())).toBeTruthy();
  });

  it('should place order', () => {
    expect(component.placeOrder()).toBeTruthy();
  });
});
