import { SportBetModel } from '../models/sport-bet.model';
import { createReducer, on } from '@ngrx/store';
import { betsActions } from './bets.actions';
import { CouponModel } from '../models/coupon-model';
import { EsportBetModel } from '../models/esport-bet.model';

export const BETS_FEATURE_KEY = 'bets';

export interface BetsState {
  sportBets: SportBetModel[];
  esportBets: EsportBetModel[];
  coupon: CouponModel;
  isLoading: boolean;
  shouldClearAmount: boolean;
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
}

export const betsReducer = createReducer(
  initialState,
  on(betsActions.fetchSportBetsSuccess, (state, action) => ({
    ...state,
    sportBets: action.bets,
  })),
  on(betsActions.fetchEsportBetsSuccess, (state, action) => ({
    ...state,
    esportBets: action.bets,
  })),
  on(betsActions.addEsportBetOption, (state, action) => ({
    ...state,
    coupon: ({
      ...state.coupon,
      esportBetOptions: state.coupon.esportBetOptions.concat(action.option),
    })
  })),
  on(betsActions.removeEsportBetOption, (state, action) => ({
    ...state,
    coupon: ({
      ...state.coupon,
      esportBetOptions: state.coupon.esportBetOptions.filter(option => option.idBetEsportOption !== action.index),
    })
  })),
  on(betsActions.addSportBetOption, (state, action) => ({
    ...state,
    coupon: ({
      ...state.coupon,
      sportBetOptions: state.coupon.sportBetOptions.concat(action.option)})
  })),
  on(betsActions.removeSportBetOption, (state, action) => ({
    ...state,
    coupon: ({
      ...state.coupon,
      sportBetOptions: state.coupon.sportBetOptions.filter(option => option.idBetSportOption !== action.index),
    })
  })),
  on(betsActions.setCouponAmount, (state, action) => ({
    ...state,
    coupon: ({
      ...state.coupon,
      amount: action.amount,
    })
  })),
  on(betsActions.placeCouponSuccess, state => ({
    ...state,
    coupon: {
      amount: 0,
      sportBetOptions: [],
      esportBetOptions: [],
    },
    shouldClearAmount: true,
  }))
);
