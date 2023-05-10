import { Component, OnInit } from '@angular/core';
import { BetsFacade } from '../../+state/bets.facade';

@Component({
  selector: 'app-bets-view',
  templateUrl: './bets-view.component.html',
  styleUrls: ['./bets-view.component.scss']
})
export class BetsViewComponent implements OnInit {

  constructor(public facade: BetsFacade) {
  }

  ngOnInit(): void {
    this.facade.init();
  }
}
