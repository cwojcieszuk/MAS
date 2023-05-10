import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { AuthService } from '../auth.service';
import { AuthActions } from './auth.actions';
import { catchError, filter, map, mergeMap, of, tap, withLatestFrom } from 'rxjs';
import { LoginSuccessProps } from './props/login-success.props';
import { ToastrService } from 'ngx-toastr';
import { LocalStorageHelpers } from '../../shared/helpers/local-storage.helpers';
import { AuthFacade } from './auth.facade';
import { betsActions } from '../../bets/+state/bets.actions';

@Injectable({ providedIn: 'root' })
export class AuthEffects {

  login$ = createEffect(() =>
    this.actions$.pipe(
      ofType(AuthActions.login),
      mergeMap(params => this.authService.login(params).pipe(
        map(result => AuthActions.loginSuccess(new LoginSuccessProps(result.accessToken))),
        catchError(() => of(AuthActions.loginFailure()))
      ))
    ));

  loginSuccess$ = createEffect(() =>
    this.actions$.pipe(
      ofType(AuthActions.loginSuccess),
      tap(action => LocalStorageHelpers.setAccessToken(action.accessToken))
    ), { dispatch: false });

  loginFail$ = createEffect(() =>
    this.actions$.pipe(
      ofType(AuthActions.loginFailure, AuthActions.registerFailure),
      tap(() => this.toastr.error('Akcja się nie powiodła'))
    ), { dispatch: false });

  register$ = createEffect(() =>
    this.actions$.pipe(
      ofType(AuthActions.register),
      mergeMap(params => this.authService.register(params).pipe(
        map(result => AuthActions.registerSuccess(new LoginSuccessProps(result.accessToken))),
        catchError(() => of(AuthActions.registerFailure()))
      ))
    ));

  registerSuccess$ = createEffect(() =>
    this.actions$.pipe(
      ofType(AuthActions.registerSuccess),
      tap(action => LocalStorageHelpers.setAccessToken(action.accessToken))
    ), { dispatch: false });

  fetchAccount = createEffect(() =>
    this.actions$.pipe(
      ofType(AuthActions.fetchAccount),
      withLatestFrom(this.authFacade.user$),
      map(([, user]) => user?.userId),
      filter(Boolean),
      mergeMap(userId => this.authService.getAccount(userId).pipe(
        map(result => AuthActions.fetchAccountSuccess(result)),
        catchError(() => of(AuthActions.fetchAccountFailure()))
      ))
    ));

  init$ = createEffect(() =>
    this.actions$.pipe(
      ofType(AuthActions.init, AuthActions.addMoneySuccess, betsActions.placeCouponSuccess),
      map(() => AuthActions.fetchAccount())
    ));

  addMoney$ = createEffect(() =>
    this.actions$.pipe(
      ofType(AuthActions.addMoney),
      withLatestFrom(this.authFacade.user$),
      filter(Boolean),
      mergeMap(([action, user]) => this.authService.addMoney(action.amount, user?.userId).pipe(
        map(() => AuthActions.addMoneySuccess()),
        catchError(() => of(AuthActions.addMoneyFailure()))
      ))
    ));

  addMoneySuccess$ = createEffect(() =>
    this.actions$.pipe(
      ofType(AuthActions.addMoneySuccess),
      tap(() => this.toastr.success('Pomyślnie doładowano konto'))
    ), { dispatch: false });

  addMoneyFailure = createEffect(() =>
    this.actions$.pipe(
      ofType(AuthActions.addMoneyFailure),
      tap(() => this.toastr.error('Nie udało się doładować konta'))
    ), { dispatch: false });

  constructor(
    private readonly actions$: Actions,
    private readonly authService: AuthService,
    private readonly toastr: ToastrService,
    private readonly authFacade: AuthFacade
  ) {}
}
