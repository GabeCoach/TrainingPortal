import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import 'rxjs/add/operator/filter';
import * as OktaAuth from '@okta/okta-auth-js';

@Injectable()
export class AuthService {

  constructor(public router: Router) {}

  oktaAuth = new OktaAuth({
    url: 'https://dev-157884.oktapreview.com',
    clientId: '0oae8qc4ooxRcHxeD0h7',
    issuer: 'https://dev-157884.oktapreview.com/oauth2/{authorizationServerId}',
    redirectUri: 'http://localhost:4200/callback',
  });


  async handleAuthentication() {
    const tokens = await this.oktaAuth.token.parseFromUrl();
    tokens.forEach(token => {
      if (token.idToken) {
        this.oktaAuth.tokenManager.add('idToken', token);
      }
      if (token.accessToken) {
        this.oktaAuth.tokenManager.add('accessToken', token);
      }
    });
  }

  async logout() {
    this.router.navigate(['/']);
    this.oktaAuth.tokenManager.clear();
    await this.oktaAuth.signOut();
  }

  isAuthenticated() {
    // Checks if there is a current accessToken in the TokenManger.
    return !!this.oktaAuth.tokenManager.get('accessToken');
  }

  login() {
    // Launches the login redirect.
    this.oktaAuth.token.getWithRedirect({
      responseType: ['id_token', 'token'],
      scopes: ['openid', 'email', 'profile']
    });
  }

}
