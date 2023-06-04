import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProfileRoutingModule } from './profile-routing.module';
import { ProfileViewComponent } from './views/profile-view/profile-view.component';
import { MatCardModule } from '@angular/material/card';
import { ProfileStoreModule } from './+state/profile-store.module';
import { BasicInfoComponent } from './components/basic-info/basic-info.component';
import { ReactiveFormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatButtonModule } from '@angular/material/button';
import { AddressComponent } from './components/address/address.component';

@NgModule({
  declarations: [
    ProfileViewComponent,
    BasicInfoComponent,
    AddressComponent
  ],
  imports: [
    CommonModule,
    ProfileRoutingModule,
    MatCardModule,
    ProfileStoreModule,
    ReactiveFormsModule,
    MatInputModule,
    MatDatepickerModule,
    MatButtonModule,
  ]
})
export class ProfileModule { }
