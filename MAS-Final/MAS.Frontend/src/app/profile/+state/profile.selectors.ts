import { createFeatureSelector, createSelector } from '@ngrx/store';
import { PROFILE_FEATURE_KEY, ProfileState } from './profile.reducer';

export const getProfileState = createFeatureSelector<ProfileState>(PROFILE_FEATURE_KEY);

export const getSelectedMenuItem = createSelector(
  getProfileState,
  state => state.selectedMenuItem,
);

export const getBasicInfo = createSelector(
  getProfileState,
  state => state.basicInfo,
);

export const getAddress = createSelector(
  getProfileState,
  state => state.address,
);
