import { HttpClient, HttpHeaders } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { GuestList } from '../_modules/guest-list';
import { AccountService } from './account.service';

@Injectable({
  providedIn: 'root'
})
export class GuestListService {
  private http = inject(HttpClient);
  private accountService = inject(AccountService);
  private baseUrl = environment.apiUrl + 'guestlists/';

  private getHttpOptions() {
    const token = this.accountService.currentUser()?.token;
    return {
      headers: new HttpHeaders({
        Authorization: `Bearer ${token}`
      })
    };
  }

  getGuestLists() {
    return this.http.get<GuestList[]>(this.baseUrl, this.getHttpOptions());
  }

  getGuestList(id: number) {
    return this.http.get<GuestList>(this.baseUrl + id, this.getHttpOptions());
  }

  addGuestList(weddingId: number) {
    return this.http.post<GuestList>(this.baseUrl, { weddingId }, this.getHttpOptions());
  }

  deleteGuestList(id: number) {
    return this.http.delete<void>(this.baseUrl + id, this.getHttpOptions());
  }
}
