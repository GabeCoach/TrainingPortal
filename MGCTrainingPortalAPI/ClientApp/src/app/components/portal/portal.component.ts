import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { OktaAuthService } from '@okta/okta-angular';

@Component({
  selector: 'app-portal',
  templateUrl: './portal.component.html',
  styleUrls: ['./portal.component.css']
})
export class PortalComponent implements OnInit {

  signIn;
  router;

  constructor(public oktaAuth: OktaAuthService, router: Router) {
    this.signIn = oktaAuth;
    this.router = router;
  }

  ngOnInit() {
  }

  async logout() {
    // Terminates the session with Okta and removes current tokens.
    await this.signIn.logout();
    this.router.navigateByUrl('/');
  }

}
