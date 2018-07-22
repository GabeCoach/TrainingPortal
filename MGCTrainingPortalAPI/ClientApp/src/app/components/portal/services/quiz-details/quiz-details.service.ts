import { Injectable } from '@angular/core';
import { BaseService } from '../../../../services/base-service.service';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class QuizDetailsService {

  constructor(
    private baseService: BaseService,
    private http: HttpClient
  ) { }

  public async getQuizDetails(iQuizSheetId: number) {
    return await this.http.get(`${this.baseService.BaseUrl}QuizDetails/${iQuizSheetId}`).toPromise();
  }

}
