import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BetsRoutingModule } from './bets-routing.module';
import { BetsViewComponent } from './views/bets-view/bets-view.component';
import { HttpClientModule } from '@angular/common/http';
import { BetsStoreModule } from './+state/bets-store.module';
import { BetCardComponent } from './features/bet-card/bet-card.component';
import { MatCardModule } from '@angular/material/card';
import { RoundPipe } from '../shared/pipes/round.pipe';
import { MatChipsModule } from '@angular/material/chips';
import { MatButtonModule } from '@angular/material/button';
import { CouponCardComponent } from './features/coupon-card/coupon-card.component';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { ReactiveFormsModule } from '@angular/forms';
import { MatButtonToggleModule } from '@angular/material/button-toggle';
import { MatIconModule } from '@angular/material/icon';
import { CouponOptionCardComponent } from './features/coupon-option-card/coupon-option-card.component';
import { MatTabsModule } from '@angular/material/tabs';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';

@NgModule({
  declarations: [
    BetsViewComponent,
    BetCardComponent,
    CouponCardComponent,
    CouponOptionCardComponent
  ],
    imports: [
      CommonModule,
      BetsRoutingModule,
      HttpClientModule,
      BetsStoreModule,
      MatCardModule,
      RoundPipe,
      MatChipsModule,
      MatButtonModule,
      MatInputModule,
      MatFormFieldModule,
      ReactiveFormsModule,
      MatButtonToggleModule,
      MatIconModule,
      MatTabsModule,
      MatProgressBarModule,
      MatProgressSpinnerModule,
    ]
})
export class BetsModule { }
