import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../../services/auth.service';
import { UsersService } from '../services/user/users.service';
import { User } from '../models/user';
import { OktaAuthService } from '@okta/okta-angular';
import { HttpErrorResponse } from '@angular/common/http';
import { ValidatorService } from '../../../services/validator.service';
import { Route, Router } from '@angular/router';

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
    private oktaAuth: OktaAuthService,
    private validator: ValidatorService,
    private router: Router
  ) { }

  ngOnInit() {
   
    this.validator.ValidateUser()
      .catch((err:HttpErrorResponse) => {
        this.validator.HandleValidationResult(err);
      });

  }

}
