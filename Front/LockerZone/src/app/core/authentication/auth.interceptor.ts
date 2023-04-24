import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse
} from '@angular/common/http';
import { Observable, catchError, throwError } from 'rxjs';
import { Router } from '@angular/router';
import { AuthService } from './auth.service';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

  constructor(  private _authService: AuthService,
    private router:Router) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    let token = this._authService.GetToken();

    if (token != null) {
      request = request.clone({headers: request.headers.set('Authorization',`Bearer ${token}`),  });
    }
    // request = request.clone({
    //   headers: request.headers.set(
    //     'Accept-Language',   localStorage.getItem('lang') == null   ? 'ar-EG'  : localStorage.getItem('lang') == 'ar'  ? 'ar-EG'  : 'en-US'
    //   ),
    // });
    return next.handle(request).pipe(
      catchError((err: HttpErrorResponse) => {
        if (err.status === 401 ||err.status === 204) {
          // auto logout if 401 response returned from api
          this._authService.logout();
          this.router.navigate(['login']);
          // location.reload();
        }
        const error = err.error?.message || err.statusText;
        return throwError(error);
      })
    ) as Observable<HttpEvent<unknown>>;
  }

}
