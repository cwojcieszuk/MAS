import { AfterViewInit, Component, Input, OnInit, ViewChild } from '@angular/core';
import { SportBetModel, SportBetOption, SportBetWithOption } from '../../models/sport-bet.model';
import { NonNullableFormBuilder } from '@angular/forms';
import { BaseComponent } from '../../../shared/components/base.component';
import { BetsFacade } from '../../+state/bets.facade';
import { EsportBetModel, EsportBetOption, EsportBetWithOption } from '../../models/esport-bet.model';
import { MatChipListbox } from '@angular/material/chips';
import { BetsService } from '../../bets.service';
import { filter } from 'rxjs';

@Component({
  selector: 'app-bet-card',
  templateUrl: './bet-card.component.html',
  styleUrls: ['./bet-card.component.scss']
})
export class BetCardComponent extends BaseComponent implements OnInit, AfterViewInit {
  @Input() bet!: SportBetModel | EsportBetModel;
  @ViewChild('sportListbox') sportListBox!: MatChipListbox;
  @ViewChild('esportListbox') esportListBox!: MatChipListbox;

  lastSportIndex: number | null = null;
  lastEsportIndex: number | null = null;

  sportBet: SportBetModel | null = null;
  esportBet: EsportBetModel | null = null;

  sportBets: SportBetWithOption[] = [];
  esportBets: EsportBetWithOption[] = [];

  constructor(
    private fb: NonNullableFormBuilder,
    private facade: BetsFacade,
    private betsService: BetsService,
  ) {
    super();
  }

  emitSportBetOption(option: SportBetOption): void {
    if(this.sportBets.some(obj => obj.idBetSportOption === option.idBetSportOption)) {
      this.facade.removeSportBetOption(option.idBetSportOption);

      return;
    }

    if(this.lastSportIndex != null) {
      this.facade.removeSportBetOption(this.lastSportIndex);
    }

    this.lastSportIndex = option.idBetSportOption;

    const obj = {...this.sportBet, ...option} as SportBetWithOption;
    this.facade.addSportBetOption(obj);
  }

  emitEsportBetOption(option: EsportBetOption): void {
    if(this.esportBets.some(obj => obj.idBetEsportOption === option.idBetEsportOption)) {
      this.facade.removeEsportBetOption(option.idBetEsportOption);

      return;
    }

    if(this.lastEsportIndex != null) {
      this.facade.removeEsportBetOption(this.lastEsportIndex);
    }

    this.lastEsportIndex = option.idBetEsportOption;

    const obj = {...this.esportBet, ...option} as EsportBetWithOption;
    this.facade.addEsportBetOption(obj);
  }

  ngOnInit(): void {
    if('sportname' in this.bet) {
      this.sportBet = this.bet;
    }

    if('game' in this.bet) {
      this.esportBet = this.bet;
    }

    this.observe(this.facade.couponSportOptions$)
      .subscribe(value => { this.sportBets = value; });

    this.observe(this.facade.couponEsportOptions$)
      .subscribe(value => { this.esportBets = value; });
  }

  ngAfterViewInit(): void {
    this.observe(this.betsService.sportOptionToDelete$)
      .pipe(filter(Boolean))
      .subscribe(value => {
        this.sportListBox._chips.forEach(chip => {
          if(chip.tabIndex === value) {
            chip.deselect();
            return;
          }
        })
      });

    this.observe(this.betsService.esportOptionToDelete$)
      .pipe(filter(Boolean))
      .subscribe(value => {
        this.esportListBox._chips.forEach(chip => {
          if(chip.tabIndex === value) {
            chip.deselect();
            return;
          }
        })
      });

    this.observe(this.facade.shouldRefreshChips$)
      .subscribe(value => {
        if(value) {
         if(this.sportBet) {
           this.sportListBox._chips.forEach(chip => chip.deselect());
         }

         if(this.esportBet) {
           this.esportListBox._chips.forEach(chip => chip.deselect());
         }
        }
      });
  }
}
