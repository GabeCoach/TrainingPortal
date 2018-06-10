import { Injectable } from '@angular/core';
import { TrainingCourseModuleQuiz } from '../../models/training-course-module-quiz';
import { QuizUserSelectedAnswers } from '../../models/quiz-user-selected-answers';
import { QuizSheet } from '../../models/quiz-sheet';
import { QuizGrader } from '../../models/quiz-grader';
import { BaseService } from '../../../../../services/base-service.service';
import { HttpClient } from '@angular/common/http';



@Injectable({
  providedIn: 'root'
})
export class SubmitQuizService {

  public quiz: QuizGrader = new QuizGrader;

  constructor(
    private http: HttpClient,
    private baseService: BaseService
  ) { }

  public addQuizSheet( quizSheet: QuizSheet): void {
    this.quiz.quiz_sheet = quizSheet;
  }

  public addSelectedAnswers(selectedAnswers: QuizUserSelectedAnswers[]): void {
    this.quiz.selected_answers = selectedAnswers;
  }

  public submitQuizToServer(quizGrader: QuizGrader): Promise<any> {
    return this.http.post(`${this.baseService.BaseUrl}/TrainingCourseQuizScores/QuizGrade`, quizGrader).toPromise();
  }
}
