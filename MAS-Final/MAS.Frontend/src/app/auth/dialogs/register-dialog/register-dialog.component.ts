import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NonNullableFormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MAT_DATE_LOCALE, MatNativeDateModule } from '@angular/material/core';

@Component({
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatDialogModule,
    MatDatepickerModule,
    MatNativeDateModule,
  ],
  providers: [
    { provide: MAT_DATE_LOCALE, useValue: 'pl-PL' },
  ],
  templateUrl: './register-dialog.component.html',
  styleUrls: ['./register-dialog.component.scss']
})
export class RegisterDialogComponent {

  formGroup = this.fb.group({
    firstName: this.fb.control<string>('', Validators.required),
    lastName: this.fb.control<string>('', Validators.required),
    pesel: this.fb.control<number | null>(null, Validators.required),
    email: this.fb.control<string>('', Validators.required),
    password: this.fb.control<string>('', Validators.required),
    phoneNumber: this.fb.control<number | null>(null, Validators.required),
    dateOfBirth: this.fb.control<Date | null>(null, Validators.required),
    bankAccount: this.fb.control<string>(''),
  });

  get controls() {
    return this.formGroup.controls;
  }

  constructor(
    private fb: NonNullableFormBuilder,
    private dialogRef: MatDialogRef<void>
  ) {}

  close(): void {
    this.dialogRef.close();
  }

  onSubmit(): void {
    if(this.formGroup.invalid) {
      this.formGroup.markAsTouched();

      return;
    }

    this.dialogRef.close({
      firstName: this.controls.firstName.value,
      lastName: this.controls.lastName.value,
      pesel: this.controls.pesel.value,
      email: this.controls.email.value,
      password: this.controls.password.value,
      phoneNumber: this.controls.phoneNumber.value,
      dateOfBirth: this.controls.dateOfBirth.value,
      bankAccount: this.controls.bankAccount.value,
    });
  }
}
