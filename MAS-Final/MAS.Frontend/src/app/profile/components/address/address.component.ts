import { Component, OnInit } from '@angular/core';
import { NonNullableFormBuilder } from '@angular/forms';
import { ProfileFacade } from '../../+state/profile.facade';
import { BaseComponent } from '../../../shared/components/base.component';
import { filter } from 'rxjs';

@Component({
  selector: 'app-address',
  templateUrl: './address.component.html',
  styleUrls: ['./address.component.scss']
})
export class AddressComponent extends BaseComponent implements OnInit {
  readonly formGroup = this.fb.group({
    city: this.fb.control<string>(''),
    state: this.fb.control<string>(''),
    postalCode: this.fb.control<string>(''),
    street: this.fb.control<string>(''),
  });

  constructor(
    private fb: NonNullableFormBuilder,
    private facade: ProfileFacade,
  ) {
    super();
  }

  ngOnInit() {
    this.facade.fetchAddress();

    this.observe(this.facade.address$)
      .pipe(filter(Boolean))
      .subscribe(value => this.formGroup.patchValue(value));
  }

  save() {
    this.facade.updateAddress(this.formGroup.getRawValue());
  }
}
