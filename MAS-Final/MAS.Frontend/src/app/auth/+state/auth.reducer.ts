import { createReducer, on } from '@ngrx/store';
import { DecodedUserData } from '../../shared/models/decoded-user-data';
import { AuthActions } from './auth.actions';
import { LocalStorageHelpers } from '../../shared/helpers/local-storage.helpers';

export const AUTH_FEATURE_KEY = 'auth';

export interface AuthState {
  user?: DecodedUserData;
  accessToken?: string;
  money?: number;
}

const initialState: AuthState = {
  accessToken: LocalStorageHelpers.getAccessToken(),
  user: LocalStorageHelpers.getUser(LocalStorageHelpers.getAccessToken())
}

export const authReducer = createReducer(
  initialState,
  on(AuthActions.loginSuccess, AuthActions.registerSuccess, (state, action) => ({
    ...state,
    user: action.user,
    accessToken: action.accessToken,
  })),
  on(AuthActions.fetchAccountSuccess, (state, action) => ({
    ...state,
    money: action.money,
  }))
);
