import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { AuthFacade } from '../../auth/+state/auth.facade';
import { ProfileActions } from './profile.actions';
import { catchError, EMPTY, filter, map, mergeMap, of, tap, withLatestFrom } from 'rxjs';
import { ProfileService } from '../profile.service';
import { ToastrService } from 'ngx-toastr';

@Injectable({ providedIn: 'root' })
export class ProfileEffects {
  fetchBasicInfo$ = createEffect(() =>
    this.actions$.pipe(
      ofType(ProfileActions.fetchBasicInfo),
      withLatestFrom(this.authFacade.user$),
      map(([, user]) => user),
      filter(Boolean),
      mergeMap(user => this.profileService.fetchBasicInfo(user.userId).pipe(
        map(result => ProfileActions.fetchBasicInfoSuccess({ model: result })),
        catchError(() => of(ProfileActions.fetchBasicInfoFailure()))
      ))
    ));

  updateBasicInfo$ = createEffect(() =>
    this.actions$.pipe(
      ofType(ProfileActions.updateBasicInfo),
      withLatestFrom(this.authFacade.user$),
      mergeMap(([params, user]) => {
        if(!user) {
          return EMPTY;
        }

        return this.profileService.updateBasicInfo(user.userId, params).pipe(
          map(() => ProfileActions.updateBasicInfoSuccess()),
          catchError(() => of(ProfileActions.updateBasicInfoFailure()))
        )
      })
    ));

  updateBasicInfoFail$ = createEffect(() =>
    this.actions$.pipe(
      ofType(ProfileActions.updateBasicInfoFailure),
      tap(() => this.toastr.error('Akcja nie powiodła się'))
    ), { dispatch: false });

  updateBasicInfoSuccess$ = createEffect(() =>
    this.actions$.pipe(
      ofType(ProfileActions.updateBasicInfoSuccess),
      tap(() => this.toastr.success('Pomyślnie zapisano zmiany'))
    ), { dispatch: false });

  fetchAddress$ = createEffect(() =>
    this.actions$.pipe(
      ofType(ProfileActions.fetchAddress),
      withLatestFrom(this.authFacade.user$),
      map(([, user]) => user),
      filter(Boolean),
      mergeMap(user => this.profileService.fetchAddress(user.userId).pipe(
        map(result => ProfileActions.fetchAddressSuccess({ address: result })),
        catchError(() => of(ProfileActions.fetchAddressFailure()))
      ))
    ));

  updateAddress$ = createEffect(() =>
    this.actions$.pipe(
      ofType(ProfileActions.updateAddress),
      withLatestFrom(this.authFacade.user$),
      mergeMap(([params, user]) => {
        if(!user) {
          return EMPTY;
        }

        return this.profileService.updateAddress(user.userId, params).pipe(
          map(() => ProfileActions.updateAddressSuccess()),
          catchError(() => of(ProfileActions.updateAddressFailure()))
        )
      })
    ));

  constructor(
    private readonly actions$: Actions,
    private readonly authFacade: AuthFacade,
    private readonly profileService: ProfileService,
    private readonly toastr: ToastrService,
  ) {}
}
