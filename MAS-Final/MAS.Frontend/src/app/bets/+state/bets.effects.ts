import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { betsActions } from './bets.actions';
import { catchError, map, mergeMap, of, tap, withLatestFrom } from 'rxjs';
import { BetsService } from '../bets.service';
import { AuthFacade } from '../../auth/+state/auth.facade';
import { BetsFacade } from './bets.facade';
import { PlaceCouponParams } from '../models/place-coupon.params';
import { ToastrService } from 'ngx-toastr';

@Injectable({ providedIn: 'root' })
export class BetsEffects {
  init$ = createEffect(() =>
    this.actions$.pipe(
      ofType(betsActions.init),
      map(() => betsActions.fetchSportBets())
    ));

  init2$ = createEffect(() =>
    this.actions$.pipe(
      ofType(betsActions.init),
      map(() => betsActions.fetchEsportBets())
    ));

  fetchSportBets$ = createEffect(() =>
    this.actions$.pipe(
      ofType(betsActions.fetchSportBets),
      mergeMap(() => this.betsService.fetchSportBets().pipe(
        map(result => betsActions.fetchSportBetsSuccess({ bets: result })),
        catchError(() => of(betsActions.fetchSportBetsFailure()))
      ))
    ));

  fetchBetsFail$ = createEffect(() =>
    this.actions$.pipe(
      ofType(betsActions.fetchSportBetsFailure, betsActions.fetchEsportBetsFailure),
      tap(() => this.toastr.error('Nie udało się pobrać zakładów'))
    ), { dispatch: false });

  fetchEsportBets$ = createEffect(() =>
    this.actions$.pipe(
      ofType(betsActions.fetchEsportBets),
      mergeMap(() => this.betsService.fetchEsportBets().pipe(
        map(result => betsActions.fetchEsportBetsSuccess({ bets: result })),
        catchError(() => of(betsActions.fetchEsportBetsFailure()))
      ))
    ));

  placeCoupon$ = createEffect(() =>
    this.actions$.pipe(
      ofType(betsActions.placeCoupon),
      withLatestFrom(this.betsFacade.coupon$, this.authFacade.user$),
      map(([, coupon, user]) => ({ idUser: user?.userId, amount: coupon.amount, betSportOptionIds: coupon.sportBetOptions.map(option => option.idBetSportOption), betEsportOptionIds: []}) as PlaceCouponParams),
      mergeMap(params => this.betsService.placeCoupon(params).pipe(
        map(() => betsActions.placeCouponSuccess()),
        catchError(() => of(betsActions.placeCouponFailure()))
      ))
    ));

  placeCouponSuccess$ = createEffect(() =>
    this.actions$.pipe(
      ofType(betsActions.placeCouponSuccess),
      tap(() => this.toastr.success('Pomyslnie postawiono kupon!'))
    ), { dispatch: false });

  placeCouponFailure$ = createEffect(() =>
    this.actions$.pipe(
      ofType(betsActions.placeCouponFailure),
      tap(() => this.toastr.error('Nie udało się postawić kuponu'))
    ), { dispatch: false });

  constructor(
    private readonly actions$: Actions,
    private readonly betsService: BetsService,
    private readonly authFacade: AuthFacade,
    private readonly betsFacade: BetsFacade,
    private readonly toastr: ToastrService,
  ) {}
}
