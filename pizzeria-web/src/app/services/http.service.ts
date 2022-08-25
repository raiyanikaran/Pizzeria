import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

export abstract class HttpService {

  private API_URL = environment.API_URL;
  private headers = new HttpHeaders().set('Content-Type', 'application/json');

  constructor(protected httpClient: HttpClient) { }

  get(endpoint: string, params: any): Observable<any> {
    return this.httpClient.get(
      this.API_URL + endpoint,
      { headers: this.headers, params: params }
    );
  }

  post(endpoint: string, body: any): Observable<any> {
    return this.httpClient.post(
      this.API_URL + endpoint,
      body,
      { headers: this.headers }
    );
  }

  put(endpoint: string, body: any) {
    return this.httpClient.put(
      this.API_URL + endpoint,
      body,
      { headers: this.headers }
    );
  }

  delete(endpoint: string) {
    return this.httpClient.delete(
      this.API_URL + endpoint, { headers: this.headers }
    );
  }

}
