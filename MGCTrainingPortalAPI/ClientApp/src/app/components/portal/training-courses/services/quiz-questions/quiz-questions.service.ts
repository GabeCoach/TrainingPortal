import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../../../services/base-service.service';
import { QuizQuestions } from '../../models/quiz-questions';

@Injectable()
export class QuizQuestionsService {

  constructor(private http: HttpClient, private baseService: BaseService) { }

  public async getQuizQuestions(): Promise<any> {
    return await this.http.get(this.baseService.BaseUrl + 'QuizQuestions').toPromise();
  }

  public async getQuizQuestionById(Id: number): Promise<any> {
    return await this.http.get(this.baseService.BaseUrl + 'QuizQuestions/' + Id).toPromise();
  }

  public async getQuizQuestionsByModuleQuiz(iQuizId: number): Promise<any> {
    return await this.http.get(`${this.baseService.BaseUrl}/QuizQuestions/${iQuizId}/TrainingCourseModuleQuiz`).toPromise();
  }

  public async postQuizQuestion(quizQuestion: QuizQuestions): Promise<any> {
    return await this.http.post(this.baseService.BaseUrl + 'QuizQuestions', quizQuestion).toPromise();
  }

  public async updateQuizQuestion(quizQuestion: QuizQuestions, Id: number): Promise<any> {
    return await this.http.put(this.baseService.BaseUrl + 'QuizQuestions/' + Id, quizQuestion).toPromise();
  }

  public async deleteQuizQuestion(Id: number): Promise<any> {
    return await this.http.delete(this.baseService.BaseUrl + 'QuizQuestions/' + Id).toPromise();
  }

}
