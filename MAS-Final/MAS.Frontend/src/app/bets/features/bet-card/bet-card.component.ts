import { Component, Input, OnInit } from '@angular/core';
import { SportBetModel, SportBetOption, SportBetWithOption } from '../../models/sport-bet.model';
import { NonNullableFormBuilder } from '@angular/forms';
import { BaseComponent } from '../../../shared/components/base.component';
import { BetsFacade } from '../../+state/bets.facade';
import { filter } from 'rxjs';
import { EsportBetModel, EsportBetOption, EsportBetWithOption } from '../../models/esport-bet.model';

@Component({
  selector: 'app-bet-card',
  templateUrl: './bet-card.component.html',
  styleUrls: ['./bet-card.component.scss']
})
export class BetCardComponent extends BaseComponent implements OnInit{
  @Input() bet!: SportBetModel | EsportBetModel;

  sportBetFormControl = this.fb.control<SportBetOption | null>(null);
  esportBetFormControl = this.fb.control<EsportBetOption | null>(null);

  lastSportIndex: number | null = null;
  lastEsportIndex: number | null = null;

  sportBet: SportBetModel | null = null;
  esportBet: EsportBetModel | null = null;

  constructor(
    private fb: NonNullableFormBuilder,
    private facade: BetsFacade
  ) {
    super();
  }

  ngOnInit(): void {
    if('sportname' in this.bet) {
      this.sportBet = this.bet;
    }

    if('game' in this.bet) {
      this.esportBet = this.bet;
    }

    this.observe(this.esportBetFormControl.valueChanges)
      .pipe(filter(Boolean))
      .subscribe(value => {
        if(this.lastEsportIndex != null) {
          this.facade.removeEsportBetOption(this.lastEsportIndex);
        }

        this.lastEsportIndex = value.idBetEsportOption;

        const obj = {...this.esportBet, ...value} as EsportBetWithOption;
        this.facade.addEsportBetOption(obj);
      });

    this.observe(this.sportBetFormControl.valueChanges)
      .pipe(filter(Boolean))
      .subscribe(value => {
        if(this.lastSportIndex != null) {
          this.facade.removeSportBetOption(this.lastSportIndex);
        }

        this.lastSportIndex = value.idBetSportOption;

        const obj = {...this.sportBet, ...value} as SportBetWithOption;
        this.facade.addSportBetOption(obj);
      });
  }
}
