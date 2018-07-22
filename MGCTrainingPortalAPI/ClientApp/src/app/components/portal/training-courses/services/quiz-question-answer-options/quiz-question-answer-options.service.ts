import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../../../services/base-service.service';
import { QuizQuestionAnswerOptions } from '../../models/quiz-question-answer-options';


@Injectable()
export class QuizQuestionAnswerOptionsService {

  constructor(private http: HttpClient, private baseService: BaseService) { }

  public async getQuizQuestionAnswerOptions(): Promise<any> {
    return await this.http.get(this.baseService.BaseUrl + 'QuizQuestionAnswerOptions').toPromise();
  }

  public async getQuizQuestionAnswerOptionById(Id: number): Promise<any> {
    return await this.http.get(this.baseService.BaseUrl + 'QuizQuestionAnswerOptions/' + Id).toPromise();
  }

  public async getQuizQuestionAnswerOptionByQuestion(iQuizQuestionId: number): Promise<any> {
    return await this.http.get(`${this.baseService.BaseUrl}/QuizQuestionAnswerOptions/${iQuizQuestionId}/QuizQuestion`).toPromise();
  }

  public async postQuizQuestionAnswerOption(quizQuestionAnswerOption: QuizQuestionAnswerOptions): Promise<any> {
    return await this.http.post(this.baseService.BaseUrl + 'QuizQuestionAnswerOptions', quizQuestionAnswerOption).toPromise();
  }

  public async updateQuizQuestionAnswerOption(quizQuestionAnswerOption: QuizQuestionAnswerOptions, Id: number): Promise<any> {
    return await this.http.put(this.baseService.BaseUrl + 'QuizQuestionAnswerOptions/' + Id, quizQuestionAnswerOption).toPromise();
  }

  public async deleteQuizQuestionAnswerOption(Id: number): Promise<any> {
    return await this.http.delete(this.baseService.BaseUrl + 'QuizQuestionAnswerOptions/' + Id).toPromise();
  }

}
