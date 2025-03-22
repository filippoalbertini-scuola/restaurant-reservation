import { Component, OnInit } from '@angular/core';
import { ApiService } from '../services/api.service';
import { Customer } from '../models/customer.model';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-list-customers',
  template: `
    <div class="customers-container">
      <h2>Customers List</h2>
      <ul class="customers-list">
        <li *ngFor="let customer of customers">
          <span>E-mail: {{ customer.email }}</span>
          <span>First name: {{ customer.first_name }}</span>
          <span>Last name: {{ customer.last_name }}</span>
        </li>
      </ul>
    </div>
  `,
  styles: [`
    .customers-container {
      padding: 20px;
      background-color: #f8f9fa;
      border: 1px solid #dee2e6;
      border-radius: 6px;
      font-family: 'Arial', sans-serif;
    }
    .customers-container h2 {
      text-align: center;
      font-size: 24px;
      font-weight: bold;
      margin-bottom: 20px;
    }
    .customers-list {
      list-style-type: none;
      padding: 0;
    }
    .customers-list li {
      display: flex;
      justify-content: space-between;
      padding: 10px;
      border-bottom: 1px solid #dee2e6;
    }
    .customers-list li span {
      font-size: 14px;
      color: #6c757d;
    }
  `],
    imports: [CommonModule]
})
export class ListCustomersComponent implements OnInit {
  customers: Customer[] = [];

  constructor(private apiService: ApiService) {}

  ngOnInit(): void {
    console.log('ngOnInit');
    this.apiService.getCustomers().subscribe((data: Customer[]) => {
      this.customers = data;
      console.log('customers', JSON.stringify(data));
    });
  }
}
