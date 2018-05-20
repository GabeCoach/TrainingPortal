import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor} from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { OktaAuthService } from '@okta/okta-angular';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

  constructor(public oktaAuth: OktaAuthService) {}

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    // tslint:disable-next-line:prefer-const
    let sToken = this.oktaAuth.getIdToken().idToken;

    request = request.clone({
      setHeaders: {
        Authorization: `Bearer ${sToken}`
      }
    });
    return next.handle(request);
  }
}
