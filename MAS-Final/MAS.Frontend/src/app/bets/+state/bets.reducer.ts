import { SportBetModel } from '../models/sport-bet.model';
import { createReducer, on } from '@ngrx/store';
import { BetsActions } from './bets.actions';
import { CouponModel } from '../models/coupon-model';
import { EsportBetModel } from '../models/esport-bet.model';

export const BETS_FEATURE_KEY = 'bets';

export interface BetsState {
  sportBets: SportBetModel[];
  esportBets: EsportBetModel[];
  coupon: CouponModel;
  isLoading: boolean;
  shouldClearAmount: boolean;
  isCouponLoading: boolean;
  shouldRefreshChips: boolean;
}

const initialState: BetsState = {
  sportBets: [],
  esportBets: [],
  isLoading: false,
  coupon: {
    amount: 0,
    sportBetOptions: [],
    esportBetOptions: [],
  },
  shouldClearAmount: false,
  isCouponLoading: false,
  shouldRefreshChips: false,
}

export const betsReducer = createReducer(
  initialState,
  on(BetsActions.fetchSportBetsSuccess, (state, action) => ({
    ...state,
    sportBets: action.bets,
  })),
  on(BetsActions.fetchEsportBetsSuccess, (state, action) => ({
    ...state,
    esportBets: action.bets,
  })),
  on(BetsActions.addEsportBetOption, (state, action) => ({
    ...state,
    coupon: ({
      ...state.coupon,
      esportBetOptions: state.coupon.esportBetOptions.concat(action.option),
    })
  })),
  on(BetsActions.removeEsportBetOption, (state, action) => ({
    ...state,
    coupon: ({
      ...state.coupon,
      esportBetOptions: state.coupon.esportBetOptions.filter(option => option.idBetEsportOption !== action.index),
    }),
  })),
  on(BetsActions.addSportBetOption, (state, action) => ({
    ...state,
    coupon: ({
      ...state.coupon,
      sportBetOptions: state.coupon.sportBetOptions.concat(action.option)})
  })),
  on(BetsActions.removeSportBetOption, (state, action) => ({
    ...state,
    coupon: ({
      ...state.coupon,
      sportBetOptions: state.coupon.sportBetOptions.filter(option => option.idBetSportOption !== action.index),
    }),
  })),
  on(BetsActions.setCouponAmount, (state, action) => ({
    ...state,
    coupon: ({
      ...state.coupon,
      amount: action.amount,
    })
  })),
  on(BetsActions.placeCoupon, state => ({
    ...state,
    isCouponLoading: true,
    shouldClearAmount: false,
  })),
  on(BetsActions.placeCouponFailure, state => ({
    ...state,
    isCouponLoading: false,
    shouldClearAmount: false,
  })),
  on(BetsActions.placeCouponSuccess, state => ({
    ...state,
    coupon: {
      amount: 0,
      sportBetOptions: [],
      esportBetOptions: [],
    },
    shouldClearAmount: true,
    isCouponLoading: false,
    shouldRefreshChips: true,
  })),
  on(BetsActions.placeCoupon, BetsActions.placeCouponFailure, state => ({
    ...state,
    shouldRefreshChips: false,
  }))
);
