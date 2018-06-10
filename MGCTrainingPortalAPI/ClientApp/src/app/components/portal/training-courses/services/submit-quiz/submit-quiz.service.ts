import { Injectable } from '@angular/core';
import { TrainingCourseModuleQuiz } from '../../models/training-course-module-quiz';
import { QuizUserSelectedAnswers } from '../../models/quiz-user-selected-answers';
import { QuizSheet } from '../../models/quiz-sheet';
import { QuizGrader } from '../../models/quiz-grader';


@Injectable({
  providedIn: 'root'
})
export class SubmitQuizService {

  public quiz: QuizGrader = new QuizGrader;

  constructor() { }

  public addQuizSheet( quizSheet: QuizSheet): void {
    this.quiz.quiz_sheet = quizSheet;
  }

  public addSelectedAnswers(selectedAnswers: QuizUserSelectedAnswers[]): void {
    this.quiz.selected_answers = selectedAnswers;
  }
}
