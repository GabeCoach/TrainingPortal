import { Injectable } from '@angular/core';
import { User } from '../../models/user';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../../services/base-service.service';

@Injectable()
export class UsersService {

  public currentUser: User = new User;

  constructor(private http: HttpClient, private baseService: BaseService) { }

  public getUsers(): Promise<any> {
    return this.http.get(this.baseService.BaseUrl + 'Users').toPromise();
  }

  public getUserById(Id: number): Promise<any> {
    return this.http.get(this.baseService.BaseUrl + 'Users/' + Id).toPromise();
  }

  public checkIfUserExists(sOktaId: string): Promise<any> {
    return this.http.get(`${this.baseService.BaseUrl}Users/${sOktaId}/Check`).toPromise();
  }

  public createUserFromOkta(sOktaId: string): Promise<any> {
    return this.http.get(`${this.baseService.BaseUrl}Users/${sOktaId}/Okta`).toPromise();
  }

  public getUserByOktaId(sOktaId: string): Promise<any> {
    return this.http.get(`${this.baseService.BaseUrl}Users/${sOktaId}/OktaUser`).toPromise();
  }

  public postUser(user: User): Promise<any> {
    return this.http.post(this.baseService.BaseUrl + 'Users', user).toPromise();
  }

  public updateUser(user: User, Id: number): Promise<any> {
    return this.http.put(this.baseService.BaseUrl + 'Users/' + Id, user).toPromise();
  }

  public deleteUser(Id: number): Promise<any> {
    return this.http.delete(this.baseService.BaseUrl + 'Users/' + Id).toPromise();
  }
}
