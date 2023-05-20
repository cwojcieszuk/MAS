import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { BetsActions } from './bets.actions';
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
      ofType(BetsActions.init),
      map(() => BetsActions.fetchSportBets())
    ));

  init2$ = createEffect(() =>
    this.actions$.pipe(
      ofType(BetsActions.init),
      map(() => BetsActions.fetchEsportBets())
    ));

  fetchSportBets$ = createEffect(() =>
    this.actions$.pipe(
      ofType(BetsActions.fetchSportBets),
      mergeMap(() => this.betsService.fetchSportBets().pipe(
        map(result => BetsActions.fetchSportBetsSuccess({ bets: result })),
        catchError(() => of(BetsActions.fetchSportBetsFailure()))
      ))
    ));

  fetchBetsFail$ = createEffect(() =>
    this.actions$.pipe(
      ofType(BetsActions.fetchSportBetsFailure, BetsActions.fetchEsportBetsFailure),
      tap(() => this.toastr.error('Nie udało się pobrać zakładów'))
    ), { dispatch: false });

  fetchEsportBets$ = createEffect(() =>
    this.actions$.pipe(
      ofType(BetsActions.fetchEsportBets),
      mergeMap(() => this.betsService.fetchEsportBets().pipe(
        map(result => BetsActions.fetchEsportBetsSuccess({ bets: result })),
        catchError(() => of(BetsActions.fetchEsportBetsFailure()))
      ))
    ));

  placeCoupon$ = createEffect(() =>
    this.actions$.pipe(
      ofType(BetsActions.placeCoupon),
      withLatestFrom(this.betsFacade.coupon$, this.authFacade.user$),
      map(([, coupon, user]) => ({ idUser: user?.userId, amount: coupon.amount, betSportOptionIds: coupon.sportBetOptions.map(option => option.idBetSportOption), betEsportOptionIds: coupon.esportBetOptions.map(option => option.idBetEsportOption)}) as PlaceCouponParams),
      mergeMap(params => this.betsService.placeCoupon(params).pipe(
        map(() => BetsActions.placeCouponSuccess()),
        catchError(() => of(BetsActions.placeCouponFailure()))
      ))
    ));

  placeCouponSuccess$ = createEffect(() =>
    this.actions$.pipe(
      ofType(BetsActions.placeCouponSuccess),
      tap(() => this.toastr.success('Pomyslnie postawiono kupon!'))
    ), { dispatch: false });

  placeCouponFailure$ = createEffect(() =>
    this.actions$.pipe(
      ofType(BetsActions.placeCouponFailure),
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
