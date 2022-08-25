import { CommonModule } from '@angular/common';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import { MatRadioModule } from '@angular/material/radio';
import { MatTabsModule } from '@angular/material/tabs';
import { BrowserModule } from '@angular/platform-browser';
import { Routes } from '@angular/router';
import { BuildPizzaComponent } from '../build-pizza/build-pizza.component';
import { CartComponent } from '../cart/cart.component';
import { MenuComponent } from '../menu/menu.component';
import { NonPizzaItemUi } from '../models/NonPizzaItem';
import { GetNamePipe } from '../pipe/getName.pipe';
import { CommonService } from '../services/common.service';

import { DashboardComponent } from './dashboard.component';
import { DashboardModule } from './dashboard.module';

describe('DashboardComponent', () => {
  let component: DashboardComponent;
  let fixture: ComponentFixture<DashboardComponent>;
  const routes: Routes = [
    {
      path: '',
      component: DashboardComponent
    }
  ];
  
  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DashboardComponent,
        BuildPizzaComponent,
        CartComponent,
        MenuComponent,
        GetNamePipe  
      ],
      imports: [
        BrowserModule,
        FormsModule,
        ReactiveFormsModule,
        CommonModule,
        DashboardModule,
        MatButtonModule,
        MatTabsModule,
        MatIconModule,
        MatDialogModule,
        MatRadioModule
      ],
      providers: [CommonService]
    })
    .compileComponents().then(() => {
      fixture = TestBed.createComponent(DashboardComponent);
      component = fixture.componentInstance; // ContactComponent test instance
    });
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DashboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should create cart item', () => {
    expect(component.addToCart(new NonPizzaItemUi())).toBeTruthy();
  });
});
