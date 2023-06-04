import { createReducer, on } from '@ngrx/store';
import { ProfileActions } from './profile.actions';
import { BasicInfoModel } from '../models/basic-info.model';
import { UserAddressModel } from '../models/user-address.model';

export const PROFILE_FEATURE_KEY = 'profile';

export interface ProfileState {
  selectedMenuItem: number;
  basicInfo: BasicInfoModel | null;
  address: UserAddressModel | null;
}

const initialState: ProfileState = {
  selectedMenuItem: 1,
  basicInfo: null,
  address: null,
}

export const profileReducer = createReducer(
  initialState,
  on(ProfileActions.selectMenuItem, (state, payload) => ({
    ...state,
    selectedMenuItem: payload.id,
  })),
  on(ProfileActions.fetchBasicInfoSuccess, (state, payload) => ({
    ...state,
    basicInfo: payload.model,
  })),
  on(ProfileActions.fetchAddressSuccess, (state, payload) => ({
    ...state,
    address: payload.address,
  })),
);
