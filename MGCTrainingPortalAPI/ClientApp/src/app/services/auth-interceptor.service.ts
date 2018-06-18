import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/observable';
import 'rxjs/add/operator/map';
import { OktaAuthService } from '@okta/okta-angular';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

  constructor(public oktaAuth: OktaAuthService) {}

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    // tslint:disable-next-line:prefer-const
    let sToken = this.oktaAuth.getIdToken().idToken;
    const sID = this.oktaAuth.getIdToken().claims.sub;

    request = request.clone({
      setHeaders: {
        Authorization: `Bearer ${sToken}`
      }
    });

    /*
    if (request.responseType === 'json') {
      request = request.clone({ responseType: 'text' });

      return next.handle(request).map(response => {
        if (response instanceof HttpResponse) {
          response = response.clone<any>({ body: JSON.stringify(response.body) });
          console.log(JSON.stringify(response));
        }

        return response;
      });
    }
    */

    return next.handle(request);
  }
}
