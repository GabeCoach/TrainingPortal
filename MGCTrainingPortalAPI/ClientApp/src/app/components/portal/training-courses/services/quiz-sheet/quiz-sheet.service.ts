import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {QuizSheet } from '../../models/quiz-sheet';
import { BaseService } from '../../../../../services/base-service.service';

@Injectable({
  providedIn: 'root'
})
export class QuizSheetService {

  constructor(
    private http: HttpClient,
    private baseService: BaseService
  ) { }

  public submitQuizSheet(quizSheet: QuizSheet): Promise<any> {
    return this.http.post(`${this.baseService.BaseUrl}QuizSheets`, quizSheet).toPromise();
  }

}
