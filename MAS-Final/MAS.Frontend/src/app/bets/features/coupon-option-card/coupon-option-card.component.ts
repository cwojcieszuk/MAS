import { Component, Input, OnInit } from '@angular/core';
import { SportBetWithOption } from '../../models/sport-bet.model';
import { BetsFacade } from '../../+state/bets.facade';
import { EsportBetWithOption } from '../../models/esport-bet.model';

@Component({
  selector: 'app-coupon-option-card',
  templateUrl: './coupon-option-card.component.html',
  styleUrls: ['./coupon-option-card.component.scss']
})
export class CouponOptionCardComponent implements OnInit {
  @Input() couponOption!: SportBetWithOption | EsportBetWithOption;

  sportOption: SportBetWithOption | null = null;
  esportOption: EsportBetWithOption | null = null;

  constructor(public facade: BetsFacade) {
  }

  ngOnInit(): void {
    if('game' in this.couponOption) {
      this.esportOption = this.couponOption;
    }

    if('sportname' in this.couponOption) {
      this.sportOption = this.couponOption;
    }
  }

  removeEsportOption(index: number): void {
    this.facade.removeEsportBetOption(index);
  }

  removeSportOption(index: number): void {
    this.facade.removeSportBetOption(index)
  }
}
