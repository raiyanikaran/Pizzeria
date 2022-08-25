import { Component, OnInit } from '@angular/core';
import { User } from './models/User';
import { CommonService } from './services/common.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{
  title = 'pizzeria-web';

  constructor(public commonService: CommonService) {
    this.commonService.getUsers();
    this.commonService.getAllItems();
  }

  ngOnInit() {
    this.commonService.currentUserId = sessionStorage.User ? sessionStorage.User : 1;
    this.onSelectUser(this.commonService.currentUserId);
  }

  onSelectUser(userId: any) {
    sessionStorage.setItem('User', userId.toString());
    this.commonService.getOrders(Number(userId));
  }

}
