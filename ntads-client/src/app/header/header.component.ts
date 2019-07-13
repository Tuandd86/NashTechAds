import { Component, OnInit } from '@angular/core';
import { AdalService } from 'adal-angular4';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  constructor(private adalService: AdalService) { }

  ngOnInit() {

    this.adalService.handleWindowCallback();

    console.log(this.adalService.userInfo);
  }

  login() {
    this.adalService.login();
  }

  logout() {
    this.adalService.logOut();
  }

  get userInfo(): any {
    return this.adalService.userInfo;
  }

  get authenticated(): boolean {
    return this.adalService.userInfo.authenticated;
  }
}