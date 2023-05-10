import { Component, OnInit } from '@angular/core';
import { BetsFacade } from '../../+state/bets.facade';
import { NonNullableFormBuilder, Validators } from '@angular/forms';
import { BaseComponent } from '../../../shared/components/base.component';
import { AuthFacade } from '../../../auth/+state/auth.facade';

@Component({
  selector: 'app-coupon-card',
  templateUrl: './coupon-card.component.html',
  styleUrls: ['./coupon-card.component.scss']
})
export class CouponCardComponent extends BaseComponent implements OnInit {
  amountFormControl = this.fb.control<number>(0, [Validators.required, Validators.min(2)]);

  authError: boolean = false;

  constructor(
    public facade: BetsFacade,
    private fb: NonNullableFormBuilder,
    public authFacade: AuthFacade,
  ) {
    super();


  }

  ngOnInit(): void {
    this.observe(this.facade.shouldClearAmount$)
      .subscribe(value => {
        if(value) {
          this.amountFormControl.reset(0);
        }
      })

    this.observe(this.amountFormControl.valueChanges)
      .subscribe(value => this.facade.setCouponAmount(+value));
  }

  placeCoupon(): void {
    this.observe(this.authFacade.user$)
      .subscribe(user => {
        if(user == null) {
          this.authError = true;
        }
      });

    if(!this.authError) {
      this.facade.placeCoupon();
    }
  }
}
