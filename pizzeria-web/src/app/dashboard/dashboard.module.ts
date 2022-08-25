import { NgModule } from '@angular/core';
import { DashboardComponent } from './dashboard.component';
import { CartComponent } from '../cart/cart.component';
import { BuildPizzaComponent } from '../build-pizza/build-pizza.component';
import { RouterModule, Routes } from '@angular/router';
import { MenuComponent } from '../menu/menu.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatTabsModule } from '@angular/material/tabs';
import { MatIconModule } from '@angular/material/icon';
import { GetNamePipe } from '../pipe/getName.pipe';
import {MatDialogModule} from '@angular/material/dialog';
import {MatRadioModule} from '@angular/material/radio';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from '../header/header.component';

const routes: Routes = [
  {
    path: '',
    component: DashboardComponent
  }
];

@NgModule({
  declarations: [
    DashboardComponent,
    BuildPizzaComponent,
    CartComponent,
    MenuComponent,
    HeaderComponent,
    GetNamePipe
  ],
  imports: [
    FormsModule,
    ReactiveFormsModule,
    CommonModule,
    RouterModule.forChild(routes),
    MatButtonModule,
    MatTabsModule,
    MatIconModule,
    MatDialogModule,
    MatRadioModule
  ],
  providers: []
})

export class DashboardModule { }
