import { Component, OnInit } from '@angular/core';
import { CommonService } from '../services/common.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  constructor(public commonService: CommonService) { }

  ngOnInit() {
    this.commonService.currentUserId = sessionStorage.User ? sessionStorage.User : 1;
    this.onSelectUser(this.commonService.currentUserId);
  }

  onSelectUser(userId: any) {
    sessionStorage.setItem('User', userId.toString());
    this.commonService.getOrders(Number(userId));
  }

}
