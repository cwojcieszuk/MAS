import { SportBetWithOption } from './sport-bet.model';
import { EsportBetWithOption } from './esport-bet.model';

export interface CouponModel {
  sportBetOptions: SportBetWithOption[];
  esportBetOptions: EsportBetWithOption[];
  amount: number;
}
