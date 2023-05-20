import { createAction, props } from '@ngrx/store';
import { SportBetModel, SportBetWithOption } from '../models/sport-bet.model';
import { EsportBetModel, EsportBetWithOption } from '../models/esport-bet.model';

export const BetsActions = {
  init: createAction(
    '[Bets/API] Init',
  ),
  fetchSportBets: createAction(
    '[Bets/API] Fetch sport bets',
  ),
  fetchSportBetsSuccess: createAction(
    '[Bets/API] Fetch sport bets success',
    props<{ bets: SportBetModel[] }>(),
  ),
  fetchSportBetsFailure: createAction(
    '[Bets/API] Fetch sport bets failure',
  ),
  addEsportBetOption: createAction(
    '[Bets/API] Add esport bet option',
    props<{ option: EsportBetWithOption }>()
  ),
  removeEsportBetOption: createAction(
    '[Bets/API] Remove esport bet option',
    props<{ index: number}>(),
  ),
  addSportBetOption: createAction(
    '[Bets/API] Add sport bet option',
    props<{ option: SportBetWithOption }>(),
  ),
  removeSportBetOption: createAction(
    '[Bets/API] Remove sport bet option',
    props<{ index: number}>(),
  ),
  setCouponAmount: createAction(
    '[Bets/API] Set coupon amount',
    props<{ amount: number }>(),
  ),
  placeCoupon: createAction(
    '[Bets/API] Place coupon',
  ),
  placeCouponSuccess: createAction(
    '[Bets/API] Place coupon success',
  ),
  placeCouponFailure: createAction(
    '[Bets/API] Place coupon failure',
  ),
  fetchEsportBets: createAction(
    '[Bets/API] Fetch esport bets',
  ),
  fetchEsportBetsSuccess: createAction(
    '[Bets/API] Fetch esport bets success',
    props<{ bets: EsportBetModel[] }>(),
  ),
  fetchEsportBetsFailure: createAction(
    '[Bets/API] Fetch esport bets failure',
  ),
};
