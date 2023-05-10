import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LoginRequestProps } from './+state/props/login-request.props';
import { Observable } from 'rxjs';
import { RegisterRequestProps } from './+state/props/register-request.props';
import { UserAccountModel } from '../shared/models/user-account.model';

export interface AuthResponse {
  accessToken: string;
}

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  readonly url = 'https://localhost:5001/api/auth';

  constructor(private http: HttpClient) { }

  login(params: LoginRequestProps): Observable<AuthResponse> {
    return this.http.post<AuthResponse>(`${this.url}/login`, params);
  }

  register(params: RegisterRequestProps): Observable<AuthResponse> {
    return this.http.post<AuthResponse>(`${this.url}/register`, params);
  }

  getAccount(userId: number): Observable<UserAccountModel> {
    return this.http.get<UserAccountModel>(`${this.url}/${userId}`);
  }

  addMoney(amount: number, userId: number | undefined) {
    return this.http.post(`${this.url}/money`, { amount, IdUser: userId });
  }
}
