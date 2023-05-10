import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NonNullableFormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';

@Component({
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, MatFormFieldModule, MatInputModule, MatButtonModule],
  templateUrl: './add-money-dialog.component.html',
  styleUrls: ['./add-money-dialog.component.scss']
})
export class AddMoneyDialogComponent {

  amountControl = this.fb.control<number>(0, Validators.required);

  constructor(
    private fb: NonNullableFormBuilder,
    private dialogRef: MatDialogRef<void>
  ) {}

  close(): void {
    this.dialogRef.close();
  }

  onSubmit(): void {
    if(this.amountControl.invalid) {
      this.amountControl.markAsTouched();

      return;
    }

    this.dialogRef.close({
      amount: this.amountControl.value,
    });
  }
}
