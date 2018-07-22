import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { OktaAuthService } from '@okta/okta-angular';
import { UsersService } from './services/user/users.service';
import { User } from './models/user';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-portal',
  templateUrl: './portal.component.html',
  styleUrls: ['./portal.component.css']
})
export class PortalComponent implements OnInit {

  public currentUser: User = new User;

  constructor(
    public oktaAuth: OktaAuthService, 
    private router: Router,
    private usersService: UsersService
  ) {

  }

  ngOnInit() {
    

  }

}
