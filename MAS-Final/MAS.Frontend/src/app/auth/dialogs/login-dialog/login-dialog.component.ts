import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NonNullableFormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-login-dialog',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, MatFormFieldModule, MatInputModule, MatButtonModule, MatDialogModule],
  templateUrl: './login-dialog.component.html',
  styleUrls: ['./login-dialog.component.scss']
})
export class LoginDialogComponent {
  formGroup = this.fb.group({
    email: this.fb.control<string>('', Validators.required),
    password: this.fb.control<string>('', Validators.required),
  })

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
      email: this.formGroup.controls.email.value,
      password: this.formGroup.controls.password.value
    });
  }
}
