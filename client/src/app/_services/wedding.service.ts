import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Wedding } from '../_modules/wedding';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class WeddingService {
  apiUrl = environment.apiUrl + 'weddings';

  constructor(private http: HttpClient) {}

  getAllWeddings(): Observable<Wedding[]> {
    return this.http.get<Wedding[]>(this.apiUrl);
  }

 getWeddingById(): Observable<Wedding> {
  const token = localStorage.getItem('token') || '';
  const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
  return this.http.get<Wedding>(`${this.apiUrl}`, { headers });
}


  createWedding(wedding: Partial<Wedding>): Observable<Wedding> {
    return this.http.post<Wedding>(this.apiUrl, wedding);
  }

  updateWedding(id: number, wedding: Partial<Wedding>): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, wedding);
  }

  deleteWedding(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }

getWeddingWithHeaders(id: number): Observable<HttpResponse<Wedding>> {
  const token = localStorage.getItem('token');
  const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);

  return this.http.get<Wedding>(`${this.apiUrl}/${id}`, { headers, observe: 'response' });
}
}
