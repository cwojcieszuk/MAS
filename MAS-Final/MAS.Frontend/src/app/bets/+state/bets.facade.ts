import { Injectable } from '@angular/core';
import { Store } from '@ngrx/store';
import {
  canPlaceCoupon,
  getCoupon,
  getCouponEsportOptions,
  getCouponOptions,
  getCouponSportOptions,
  getEsportBets,
  getFullRate,
  getIsCouponLoading,
  getPotentialWin,
  getShouldRefreshChips,
  getSportBets,
  shouldClearAmount
} from './bets.selectors';
import { BetsActions } from './bets.actions';
import { SportBetWithOption } from '../models/sport-bet.model';
import { EsportBetWithOption } from '../models/esport-bet.model';

@Injectable({ providedIn: 'root' })
export class BetsFacade {
  sportBets$ = this.store.select(getSportBets);
  esportBets$ = this.store.select(getEsportBets);
  coupon$ = this.store.select(getCoupon);
  fullRate$ = this.store.select(getFullRate);
  potentialWin$ = this.store.select(getPotentialWin);
  canPlaceCupon$ = this.store.select(canPlaceCoupon);
  shouldClearAmount$ = this.store.select(shouldClearAmount);
  couponOptions$ = this.store.select(getCouponOptions);
  isCouponLoading$ = this.store.select(getIsCouponLoading);
  couponSportOptions$ = this.store.select(getCouponSportOptions);
  couponEsportOptions$ = this.store.select(getCouponEsportOptions);
  shouldRefreshChips$ = this.store.select(getShouldRefreshChips);

  constructor(private store: Store) {}

  init(): void {
    this.store.dispatch(BetsActions.init());
  }

  addSportBetOption(option: SportBetWithOption): void {
    this.store.dispatch(BetsActions.addSportBetOption({ option }));
  }

  addEsportBetOption(option: EsportBetWithOption): void {
    this.store.dispatch(BetsActions.addEsportBetOption({ option }));
  }

  removeEsportBetOption(index: number): void {
    this.store.dispatch(BetsActions.removeEsportBetOption({ index }));
  }

  removeSportBetOption(index: number): void {
    this.store.dispatch(BetsActions.removeSportBetOption({ index }));
  }

  setCouponAmount(amount: number): void {
    this.store.dispatch(BetsActions.setCouponAmount({ amount }));
  }

  placeCoupon(): void {
    this.store.dispatch(BetsActions.placeCoupon());
  }
}
