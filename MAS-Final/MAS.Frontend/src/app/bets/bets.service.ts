import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { SportBetModel } from './models/sport-bet.model';
import { PlaceCouponParams } from './models/place-coupon.params';
import { EsportBetModel } from './models/esport-bet.model';

@Injectable({
  providedIn: 'root'
})
export class BetsService {
  private readonly url = 'https://localhost:5001/api';
  sportOptionToDelete$ = new BehaviorSubject<number | null>(null);
  esportOptionToDelete$ = new BehaviorSubject<number | null>(null);

  constructor(private http: HttpClient) { }

  fetchSportBets(): Observable<SportBetModel[]> {
    return this.http.get<SportBetModel[]>(`${this.url}/bets/sport`);
  }

  fetchEsportBets(): Observable<EsportBetModel[]> {
    return this.http.get<EsportBetModel[]>(`${this.url}/bets/esport`);
  }

  placeCoupon(body: PlaceCouponParams) {
    return this.http.post(`${this.url}/coupons`, body);
  }
}
