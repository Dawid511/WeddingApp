import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class GuestService {
  private baseUrl = environment.apiUrl + 'guests';

  constructor(private http: HttpClient) {}

  private getHeaders(): HttpHeaders {
    const token = localStorage.getItem('token');
    return new HttpHeaders({
      Authorization: `Bearer ${token}`
    });
  }

  getGuests(): Observable<any[]> {
    return this.http.get<any[]>(this.baseUrl, { headers: this.getHeaders() });
  }

  addGuest(fullName: string, count: number): Observable<any> {
    return this.http.post(this.baseUrl, { fullName, count }, { headers: this.getHeaders() });
  }

  deleteGuest(id: number): Observable<any> {
    return this.http.delete(`${this.baseUrl}/${id}`, { headers: this.getHeaders() });
  }
}
