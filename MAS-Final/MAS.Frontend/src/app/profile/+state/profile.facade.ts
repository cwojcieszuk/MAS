import { Injectable } from '@angular/core';
import { Store } from '@ngrx/store';
import { ProfileActions } from './profile.actions';
import { getAddress, getBasicInfo, getSelectedMenuItem } from './profile.selectors';
import { BasicInfoModel } from '../models/basic-info.model';
import { UserAddressModel } from '../models/user-address.model';

@Injectable({ providedIn: 'root' })
export class ProfileFacade {
  selectedMenuItem$ = this.store.select(getSelectedMenuItem);
  basicInfo$ = this.store.select(getBasicInfo);
  address$ = this.store.select(getAddress);

  constructor(private store: Store) {}

  fetchBasicInfo() {
    this.store.dispatch(ProfileActions.fetchBasicInfo());
  }

  fetchAddress() {
    this.store.dispatch(ProfileActions.fetchAddress());
  }

  updateBasicInfo(params: BasicInfoModel) {
    this.store.dispatch(ProfileActions.updateBasicInfo(params));
  }

  updateAddress(params: UserAddressModel) {
    this.store.dispatch(ProfileActions.updateAddress(params));
  }

  selectMenuItem(id: number) {
    this.store.dispatch(ProfileActions.selectMenuItem({ id }));
  }
}
