import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../../../services/base-service.service';
import { QuizQuestionCorrectAnswer } from '../../models/quiz-question-correct-answer';

@Injectable()
export class QuizQuestionCorrectAnswersService {

  constructor(private http: HttpClient, private baseService: BaseService) { }

  public getQuizQuestionCorrectAnswers(): Promise<any> {
    return this.http.get(this.baseService.BaseUrl + 'QuizQuestionCorrectAnswers').toPromise();
  }

  public getQuizQuestionCorrectAnswerById(Id: number): Promise<any> {
    return this.http.get(this.baseService.BaseUrl + 'QuizQuestionCorrectAnswers/' + Id).toPromise();
  }


  public postQuizQuestionCorrectAnswer(quizQuestionCorrectAnswer: QuizQuestionCorrectAnswer): Promise<any> {
    return this.http.post(this.baseService.BaseUrl + 'QuizQuestionCorrectAnswers', quizQuestionCorrectAnswer).toPromise();
  }

  public updateQuizQuestionCorrectAnswer(quizQuestionCorrectAnswer: QuizQuestionCorrectAnswer, Id: number): Promise<any> {
    return this.http.put(this.baseService.BaseUrl + 'QuizQuestionCorrectAnswers/' + Id, quizQuestionCorrectAnswer).toPromise();
  }

  public deleteQuizQuestionCorrectAnswer(Id: number): Promise<any> {
    return this.http.delete(this.baseService.BaseUrl + 'QuizQuestionCorrectAnswers/' + Id).toPromise();
  }

}
