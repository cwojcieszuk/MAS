import { createFeatureSelector, createSelector } from '@ngrx/store';
import { AUTH_FEATURE_KEY, AuthState } from './auth.reducer';

export const getAuthState = createFeatureSelector<AuthState>(AUTH_FEATURE_KEY);

export const getUser = createSelector(
  getAuthState,
  state => state.user
);

export const getAccessToken = createSelector(
  getAuthState,
  state => state.accessToken
);

export const getAccountMoney = createSelector(
  getAuthState,
  state => state.money
);
