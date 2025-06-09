import { inject, Injectable } from '@angular/core';
import {jwtDecode }from 'jwt-decode';
import { UserRole } from '../_modules/user';
import { Observable, tap } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../environments/environment';

export interface TokenPayload {
  id: string;
  unique_name: string; 
  role?: string;
  exp: number;
  iat: number;
}

@Injectable({ providedIn: 'root' })
export class AuthService {
  private tokenKey = 'token';
  private http = inject(HttpClient);
  baseUrl = environment.apiUrl;
  getToken(): string | null {
    return localStorage.getItem(this.tokenKey);
  }

  decodeToken(): TokenPayload | null {
    const token = this.getToken();
    if (!token) return null;

    try {
      return jwtDecode<TokenPayload>(token);
    } catch (err) {
      return null;
    }
  }

  getUserId(): number | null {
    const id = this.decodeToken()?.id;
    return id ? parseInt(id) : null;
  }

  getRole(): string | null {
    return this.decodeToken()?.role ?? null;
  }

  getUsername(): string | null {
    return this.decodeToken()?.unique_name ?? null;
  }

  setToken(token: string) {
    localStorage.setItem(this.tokenKey, token);
  }

  clearToken() {
    localStorage.removeItem(this.tokenKey);
  }

}
