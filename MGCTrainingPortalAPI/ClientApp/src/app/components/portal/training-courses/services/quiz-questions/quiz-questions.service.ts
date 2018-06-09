import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../../../services/base-service.service';
import { QuizQuestions } from '../../models/quiz-questions';

@Injectable()
export class QuizQuestionsService {

  constructor(private http: HttpClient, private baseService: BaseService) { }

  public getQuizQuestions(): Promise<any> {
    return this.http.get(this.baseService.BaseUrl + 'QuizQuestions').toPromise();
  }

  public getQuizQuestionById(Id: number): Promise<any> {
    return this.http.get(this.baseService.BaseUrl + 'QuizQuestions/' + Id).toPromise();
  }

  public getQuizQuestionsByModuleQuiz(iQuizId: number): Promise<any> {
    return this.http.get(`${this.baseService.BaseUrl}/QuizQuestions/${iQuizId}/TrainingCourseModuleQuiz`).toPromise();
  }

  public postQuizQuestion(quizQuestion: QuizQuestions): Promise<any> {
    return this.http.post(this.baseService.BaseUrl + 'QuizQuestions', quizQuestion).toPromise();
  }

  public updateQuizQuestion(quizQuestion: QuizQuestions, Id: number): Promise<any> {
    return this.http.put(this.baseService.BaseUrl + 'QuizQuestions/' + Id, quizQuestion).toPromise();
  }

  public deleteQuizQuestion(Id: number): Promise<any> {
    return this.http.delete(this.baseService.BaseUrl + 'QuizQuestions/' + Id).toPromise();
  }

}
