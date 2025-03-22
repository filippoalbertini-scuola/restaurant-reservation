import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HeaderComponent } from './components/header.component';
import { LoginComponent } from './components/login.component';
import { ListCustomersComponent } from './components/list-customers.component';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, HeaderComponent, LoginComponent, ListCustomersComponent, CommonModule],
  template: `
    <app-header
      annoscolastico="AS 24/25"
      classemateria="4G INF"
      data="26/02/2025"
      autore="Prof."
      titolo="Restaurant Reservations"
      [username]="username"
      (logoutEvent)="logout()"
    ></app-header>
    <br/>
    <div *ngIf="!isLoggedIn">
      <app-login (loginSuccess)="onLoginSuccess($event)"></app-login>
    </div>
    <div *ngIf="isLoggedIn">
      <app-list-customers></app-list-customers>
    </div>
  `,
  styles: `
  `
})
export class AppComponent {
  title = 'as2425.4f.prof.restaurantreservation';
  isLoggedIn = false;
  username = '';

  ngOnInit() {
    const token = localStorage.getItem('JWT');
    if (token) {
      this.isLoggedIn = true;
      this.username = localStorage.getItem('username') || '';
    }
  }

  onLoginSuccess(username: string) {
    this.isLoggedIn = true;
    this.username = username;
    localStorage.setItem('username', username);
  }

  logout() {
    this.isLoggedIn = false;
    this.username = '';
    localStorage.removeItem('JWT');
    localStorage.removeItem('username');
  }
}
