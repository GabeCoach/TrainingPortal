import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../../../services/auth.service';
import { HttpErrorResponse } from '@angular/common/http';
import { OktaAuthService } from '@okta/okta-angular';
import { UsersService } from '../../services/user/users.service';
import { User } from '../../models/user';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.css']
})
export class NavigationComponent implements OnInit {

  public currentUser: User = new User;

  constructor(
    public authService: AuthService,
    private usersService: UsersService,
    private oktaAuth: OktaAuthService
  ) { }

  ngOnInit() {
    let sOktaId = this.oktaAuth.getIdToken().claims.sub;

    this.usersService.checkIfUserExists(sOktaId)
    .then(resp => {

      if (resp === false) {
        this.usersService.createUserFromOkta(sOktaId)
        .then(resp => {
          this.currentUser = resp;
        }).catch((err: HttpErrorResponse) => {
          alert(err.message);
        })
      } else {
        this.usersService.getUserByOktaId(sOktaId)
        .then(resp => {
          this.currentUser = resp;
        }).catch((err: HttpErrorResponse) => {
          alert(err.message);
        })
      }

    }).catch((err: HttpErrorResponse) => {
      alert(err.message);
    })
  }

}
