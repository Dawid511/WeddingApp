import { HttpClient, HttpHeaders } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Guest } from '../_modules/guest';
import { AccountService } from './account.service';

@Injectable({
  providedIn: 'root'
})
export class GuestService {
  private http = inject(HttpClient);
  private accountService = inject(AccountService);
  private baseUrl = environment.apiUrl + 'guests/';

  private getHttpOptions() {
    const token = this.accountService.currentUser()?.token;
    return {
      headers: new HttpHeaders({
        Authorization: `Bearer ${token}`
      })
    };
  }

  getGuests() {
    return this.http.get<Guest[]>(this.baseUrl, this.getHttpOptions());
  }

  getGuest(id: number) {
    return this.http.get<Guest>(this.baseUrl + id, this.getHttpOptions());
  }

  addGuest(guest: Partial<Guest>) {
    return this.http.post<Guest>(this.baseUrl, guest, this.getHttpOptions());
  }

  updateGuest(guest: Guest) {
    return this.http.put<void>(this.baseUrl + guest.id, guest, this.getHttpOptions());
  }

  deleteGuest(id: number) {
    return this.http.delete<void>(this.baseUrl + id, this.getHttpOptions());
  }
}
