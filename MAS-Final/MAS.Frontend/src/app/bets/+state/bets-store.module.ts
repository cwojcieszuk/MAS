import { NgModule } from '@angular/core';
import { StoreModule } from '@ngrx/store';
import { BETS_FEATURE_KEY, betsReducer } from './bets.reducer';
import { EffectsModule } from '@ngrx/effects';
import { BetsEffects } from './bets.effects';

@NgModule({
  imports: [
    StoreModule.forFeature(BETS_FEATURE_KEY, betsReducer),
    EffectsModule.forFeature([BetsEffects]),
  ]
})
export class BetsStoreModule { }
