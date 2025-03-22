import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Customer } from '../models/customer.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  apiUrl: string = 'https://localhost:44384/api/';

  constructor(private httpClient: HttpClient) {}

  public getCustomers(): Observable<Customer[]> {
    return this.httpClient.get<Customer[]>(this.apiUrl + 'customers');
  }
}
