import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../../services/auth.service';
import { UsersService } from '../services/user/users.service';
import { User } from '../models/user';
import { OktaAuthService } from '@okta/okta-angular';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  public currentUser: User = new User;

  constructor(
    public authService: AuthService,
    private usersService: UsersService,
    private oktaAuth: OktaAuthService
  ) { }

  ngOnInit() {
   

  }

}
