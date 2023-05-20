import { createAction, props } from '@ngrx/store';
import { LoginRequestProps } from './props/login-request.props';
import { LoginSuccessProps } from './props/login-success.props';
import { RegisterRequestProps } from './props/register-request.props';
import { UserAccountModel } from '../../shared/models/user-account.model';

export const AuthActions = {
  init: createAction(
    '[Auth/API] Init',
  ),
  login: createAction(
    '[Auth/API] Login',
    props<LoginRequestProps>(),
  ),
  loginSuccess: createAction(
    '[Auth/API] Login success',
    props<LoginSuccessProps>(),
  ),
  loginFailure: createAction(
    '[Auth/API] Logi failure',
  ),
  register: createAction(
    '[Auth/API] Register',
    props<RegisterRequestProps>()
  ),
  registerSuccess: createAction(
    '[Auth/API] Register success',
    props<LoginSuccessProps>()
  ),
  registerFailure: createAction(
    '[Auth/API] Register failure'
  ),
  fetchAccount: createAction(
    '[Auth/API] Fetch account'
  ),
  fetchAccountSuccess: createAction(
    '[Auth/API] Fetch account success',
    props<UserAccountModel>(),
  ),
  fetchAccountFailure: createAction(
    '[Auth/API] Fetch account failure'
  ),
  addMoney: createAction(
    '[Auth/API] Add money',
    props<{ amount: number}>(),
  ),
  addMoneySuccess: createAction(
    '[Auth/API] Add money success'
  ),
  addMoneyFailure: createAction(
    '[Auth/API] Add money failure'
  ),
  logout: createAction(
    '[Auth] Logout',
  ),
}
