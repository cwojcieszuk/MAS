import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { first, map, Observable, switchMap } from 'rxjs';
import { AuthFacade } from '../+state/auth.facade';

@Injectable()
export class AccessTokenInterceptor implements HttpInterceptor {

  constructor(private authFacade: AuthFacade) {}

  intercept(request: HttpRequest<never>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    return this.authFacade.accessToken$
      .pipe(
        first(),
        map((accessToken?: string) => {
          if(!accessToken) {
            return request;
          }

          return AccessTokenInterceptor.addAuthorizationHeader(request, accessToken);
        }),
        switchMap(req => {
          return next.handle(req);
        })
      )
  }

  private static addAuthorizationHeader(req: HttpRequest<never>, accessToken: string){
    return req.clone({
      setHeaders: {
        Authorization: `Bearer ${accessToken}`,
      },
    })
  }
}
