import { createFeatureSelector, createSelector } from '@ngrx/store';
import { BETS_FEATURE_KEY, BetsState } from './bets.reducer';
import { getAccountMoney } from '../../auth/+state/auth.selectors';

export const getBetsState = createFeatureSelector<BetsState>(BETS_FEATURE_KEY);

export const getSportBets = createSelector(
  getBetsState,
  state => state.sportBets
);

export const getEsportBets = createSelector(
  getBetsState,
  state => state.esportBets
);

export const getCoupon = createSelector(
  getBetsState,
  state => state.coupon,
);

export const getFullRate = createSelector(
  getCoupon,
  coupon => {
    let fullRate = 1;
    coupon.sportBetOptions.forEach(option => {
      fullRate *= option.odds;
    });

    coupon.esportBetOptions.forEach(option => {
      fullRate *= option.odds
    });

    return fullRate == 1 ? 0 : fullRate;
  }
);

export const getPotentialWin = createSelector(
  getCoupon,
  getFullRate,
  (coupon, rate) => {
    return coupon.amount * rate;
  }
);

export const canPlaceCoupon = createSelector(
  getCoupon,
  getAccountMoney,
  (coupon, money) =>
    coupon.amount > 1 &&
    (coupon.sportBetOptions.length > 0 || coupon.esportBetOptions.length > 0)
    && money! >= coupon.amount,
);

export const shouldClearAmount = createSelector(
  getBetsState,
  state => state.shouldClearAmount,
);

export const getCouponOptions = createSelector(
  getBetsState,
  state => {
    return [...state.coupon.esportBetOptions, ...state.coupon.sportBetOptions];
  }
);

export const getCouponEsportOptions = createSelector(
  getBetsState,
  state => state.coupon.esportBetOptions,
);

export const getCouponSportOptions = createSelector(
  getBetsState,
  state => state.coupon.sportBetOptions,
);

export const getIsCouponLoading = createSelector(
  getBetsState,
  state => state.isCouponLoading,
);

export const getShouldRefreshChips = createSelector(
  getBetsState,
  state => state.shouldRefreshChips,
);
