import { Injectable } from '@angular/core';
import { Store } from '@ngrx/store';
import { LoginRequestProps } from './props/login-request.props';
import { AuthActions } from './auth.actions';
import { getAccessToken, getAccountMoney, getUser } from './auth.selectors';
import { RegisterRequestProps } from './props/register-request.props';

@Injectable({ providedIn: 'root' })
export class AuthFacade {
  user$ = this.store.select(getUser);
  accessToken$ = this.store.select(getAccessToken);
  accountMoney$ = this.store.select(getAccountMoney);

  constructor(private store: Store) {
  }

  init(): void {
    this.store.dispatch(AuthActions.init());
  }

  login(params: LoginRequestProps): void {
    this.store.dispatch(AuthActions.login(params));
  }

  register(params: RegisterRequestProps): void {
    this.store.dispatch(AuthActions.register(params));
  }

  addMoney(amount: number): void {
    this.store.dispatch(AuthActions.addMoney({ amount }));
  }
}
