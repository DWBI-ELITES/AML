import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class ApiService {
  getData<T>(): Observable<string[]> {
    throw new Error('Method not implemented.');
  }
  // private apiUrl = 'https://localhost:44356/api/values/digitalloans'; // Update with your API URL

  constructor(private httpclient: HttpClient) { }


  // getDigitalLoansExposure(): Observable<number> { 
  //   return this.httpclient.get<number>(this.apiUrl);
  // }

  getDigitalLoansExposure<T>(){ 
     return this.httpclient.get<T>('https://localhost:44356/api/values/digitalloans');
  }
}
