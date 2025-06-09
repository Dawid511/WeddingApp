import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Wedding } from '../_modules/wedding';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class WeddingService {
  apiUrl= environment.apiUrl + 'weddings';
    

  constructor(private http: HttpClient) {}

  getAllWeddings(): Observable<Wedding[]> {
    return this.http.get<Wedding[]>(this.apiUrl);
  }

  getWeddingById(id: number): Observable<Wedding> {
    return this.http.get<Wedding>(`${this.apiUrl}/${id}`);
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
}
