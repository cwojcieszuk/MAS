import { Component, OnInit } from '@angular/core';
import { NonNullableFormBuilder } from '@angular/forms';
import { BaseComponent } from '../../../shared/components/base.component';
import { ProfileFacade } from '../../+state/profile.facade';
import { filter } from 'rxjs';

@Component({
  selector: 'app-basic-info',
  templateUrl: './basic-info.component.html',
  styleUrls: ['./basic-info.component.scss']
})
export class BasicInfoComponent extends BaseComponent implements OnInit {
  readonly formGroup = this.fb.group({
    name: this.fb.control<string>(''),
    surname: this.fb.control<string>(''),
    login: this.fb.control<string>(''),
    email: this.fb.control<string>(''),
    phoneNumber: this.fb.control<number | null>(null),
    dateOfBirth: this.fb.control<Date | null>(null),
  })

  constructor(
    private fb: NonNullableFormBuilder,
    private facade: ProfileFacade,
  ) {
    super();
  }

  ngOnInit() {
    this.facade.fetchBasicInfo();

    this.observe(this.facade.basicInfo$)
      .pipe(filter(Boolean))
      .subscribe(value => {
        this.formGroup.patchValue(value);
      });
  }

  save() {
    this.facade.updateBasicInfo(this.formGroup.getRawValue());
  }
}
