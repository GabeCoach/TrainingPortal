import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../../../services/base-service.service';
import { QuizQuestionAnswerOptions } from '../../models/quiz-question-answer-options';


@Injectable()
export class QuizQuestionAnswerOptionsService {

  constructor(private http: HttpClient, private baseService: BaseService) { }

  public getQuizQuestionAnswerOptions(): Promise<any> {
    return this.http.get(this.baseService.BaseUrl + 'QuizQuestionAnswerOptions').toPromise();
  }

  public getQuizQuestionAnswerOptionById(Id: number): Promise<any> {
    return this.http.get(this.baseService.BaseUrl + 'QuizQuestionAnswerOptions/' + Id).toPromise();
  }

  public getQuizQuestionAnswerOptionByQuestion(iQuizQuestionId: number): Promise<any> {
    return this.http.get(`${this.baseService.BaseUrl}/QuizQuestionAnswerOptions/${iQuizQuestionId}/QuizQuestion`).toPromise();
  }

  public postQuizQuestionAnswerOption(quizQuestionAnswerOption: QuizQuestionAnswerOptions): Promise<any> {
    return this.http.post(this.baseService.BaseUrl + 'QuizQuestionAnswerOptions', quizQuestionAnswerOption).toPromise();
  }

  public updateQuizQuestionAnswerOption(quizQuestionAnswerOption: QuizQuestionAnswerOptions, Id: number): Promise<any> {
    return this.http.put(this.baseService.BaseUrl + 'QuizQuestionAnswerOptions/' + Id, quizQuestionAnswerOption).toPromise();
  }

  public deleteQuizQuestionAnswerOption(Id: number): Promise<any> {
    return this.http.delete(this.baseService.BaseUrl + 'QuizQuestionAnswerOptions/' + Id).toPromise();
  }

}
