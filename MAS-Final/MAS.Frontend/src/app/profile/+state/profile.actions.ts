import { createAction, props } from '@ngrx/store';
import { BasicInfoModel } from '../models/basic-info.model';
import { UserAddressModel } from '../models/user-address.model';

export const ProfileActions = {
  selectMenuItem: createAction(
    '[Profile] Select Menu Item',
    props<{ id: number }>(),
  ),
  fetchBasicInfo: createAction(
    '[Profile/API] Fetch Basic Info',
  ),
  fetchBasicInfoSuccess: createAction(
    '[Profile/API] Fetch Basic Info Success',
    props<{ model: BasicInfoModel }>(),
  ),
  fetchBasicInfoFailure: createAction(
    '[Profile/API] Fetch Basic Info Failure',
  ),
  updateBasicInfo: createAction(
    '[Profile/API] Update Basic Info',
    props<BasicInfoModel>(),
  ),
  updateBasicInfoSuccess: createAction(
    '[Profile/API] Update Basic Info Success',
  ),
  updateBasicInfoFailure: createAction(
    '[Profile/API] Update Basic Info Failure',
  ),
  fetchAddress: createAction(
    '[Profile/API] Fetch Address',
  ),
  fetchAddressSuccess: createAction(
    '[Profile/API] Fetch Address Success',
    props<{ address: UserAddressModel }>(),
  ),
  fetchAddressFailure: createAction(
    '[Profile/API] Fetch Address Failure',
  ),
  updateAddress: createAction(
    '[Profile/API] Update Address',
    props<UserAddressModel>(),
  ),
  updateAddressSuccess: createAction(
    '[Profile/API] Update Address Success',
  ),
  updateAddressFailure: createAction(
    '[Profile/API] Update Address Failure',
  ),
}
