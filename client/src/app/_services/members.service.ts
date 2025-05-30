import { HttpClient, HttpHeaders } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Member } from '../_modules/member';
import { AccountService } from './account.service';

@Injectable({
  providedIn: 'root'
})
export class MembersService {
private http = inject(HttpClient);
private accountService = inject(AccountService);
baseUrl= environment.apiUrl;
  
getMembers() {
  return this.http.get<Member[]>(this.baseUrl + 'users', this.getHttpOptions());
}

getMember(title: string){
  return this.http.get<Member>(this.baseUrl + 'users/' + title);
}

getHttpOptions() {
return{
  headers: new HttpHeaders({
  Authorization: `Bearer ${this.accountService.currentUser()?.token}`
  })
}
}
}
