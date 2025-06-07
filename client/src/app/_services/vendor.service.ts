import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Vendor } from '../_modules/vendor';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class VendorService {
private http = inject(HttpClient);
baseUrl= environment.apiUrl + 'vendors';

  getAll(): Observable<Vendor[]> {
    return this.http.get<Vendor[]>(this.baseUrl,);
  }

  getById(id: number): Observable<Vendor> {
    return this.http.get<Vendor>(`${this.baseUrl}/${id}`);
  }

  create(vendor: Vendor): Observable<Vendor> {
    return this.http.post<Vendor>(this.baseUrl, vendor);
  }

  update(id: number, vendor: Vendor): Observable<Vendor> {
    return this.http.put<Vendor>(`${this.baseUrl}/${id}`, vendor);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }

}
