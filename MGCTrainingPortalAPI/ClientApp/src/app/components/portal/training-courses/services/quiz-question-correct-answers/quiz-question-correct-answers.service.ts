import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../../../services/base-service.service';
import { QuizQuestionCorrectAnswer } from '../../models/quiz-question-correct-answer';

@Injectable()
export class QuizQuestionCorrectAnswersService {

  constructor(private http: HttpClient, private baseService: BaseService) { }

  public async getQuizQuestionCorrectAnswers(): Promise<any> {
    return await this.http.get(this.baseService.BaseUrl + 'QuizQuestionCorrectAnswers').toPromise();
  }

  public async getQuizQuestionCorrectAnswerById(Id: number): Promise<any> {
    return await this.http.get(this.baseService.BaseUrl + 'QuizQuestionCorrectAnswers/' + Id).toPromise();
  }


  public async postQuizQuestionCorrectAnswer(quizQuestionCorrectAnswer: QuizQuestionCorrectAnswer): Promise<any> {
    return await this.http.post(this.baseService.BaseUrl + 'QuizQuestionCorrectAnswers', quizQuestionCorrectAnswer).toPromise();
  }

  public async updateQuizQuestionCorrectAnswer(quizQuestionCorrectAnswer: QuizQuestionCorrectAnswer, Id: number): Promise<any> {
    return await this.http.put(this.baseService.BaseUrl + 'QuizQuestionCorrectAnswers/' + Id, quizQuestionCorrectAnswer).toPromise();
  }

  public async deleteQuizQuestionCorrectAnswer(Id: number): Promise<any> {
    return await this.http.delete(this.baseService.BaseUrl + 'QuizQuestionCorrectAnswers/' + Id).toPromise();
  }

}
