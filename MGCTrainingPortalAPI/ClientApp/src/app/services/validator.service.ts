import { Injectable } from '@angular/core'; 
import { BaseService } from './base-service.service';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class ValidatorService {

  constructor(
    private http: HttpClient,
    private baseService: BaseService,
    private router: Router
  ) { }

  public async ValidateUser(): Promise<any> {
    return await this.http.get(`${this.baseService.BaseUrl}/api/Validator`).toPromise();
  }

  public async HandleValidationResult(err: HttpErrorResponse): Promise<any> {
    switch(err.status) {
      case 401:
        this.router.navigate(['/login']);
      case 403:
        this.router.navigate(['login']);
    }
  }
}
