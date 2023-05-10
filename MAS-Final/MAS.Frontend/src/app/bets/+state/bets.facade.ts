import { Injectable } from '@angular/core';
import { Store } from '@ngrx/store';
import {
  canPlaceCoupon,
  getCoupon, getCouponOptions, getEsportBets,
  getFullRate,
  getPotentialWin,
  getSportBets,
  shouldClearAmount
} from './bets.selectors';
import { betsActions } from './bets.actions';
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

  constructor(private store: Store) {}

  init(): void {
    this.store.dispatch(betsActions.init());
  }

  addSportBetOption(option: SportBetWithOption): void {
    this.store.dispatch(betsActions.addSportBetOption({ option }));
  }

  addEsportBetOption(option: EsportBetWithOption): void {
    this.store.dispatch(betsActions.addEsportBetOption({ option }));
  }

  removeEsportBetOption(index: number): void {
    this.store.dispatch(betsActions.removeEsportBetOption({ index }));
  }

  removeSportBetOption(index: number): void {
    this.store.dispatch(betsActions.removeSportBetOption({ index }));
  }

  setCouponAmount(amount: number): void {
    this.store.dispatch(betsActions.setCouponAmount({ amount }));
  }

  placeCoupon(): void {
    this.store.dispatch(betsActions.placeCoupon());
  }
}
