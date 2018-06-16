import { Component, OnInit } from '@angular/core';
import { QuizGrader } from '../models/quiz-grader';
import { SubmitQuizService } from '../services/submit-quiz/submit-quiz.service';
import { TrainingCourseQuizScores } from '../models/training-course-quiz-scores';
import { HttpErrorResponse } from '@angular/common/http';
import { QuizUserSelectedAnswers } from '../models/quiz-user-selected-answers';

@Component({
  selector: 'app-submit-quiz',
  templateUrl: './submit-quiz.component.html',
  styleUrls: ['./submit-quiz.component.css']
})
export class SubmitQuizComponent implements OnInit {

  public quizScores: TrainingCourseQuizScores;
  public postQuizObject: QuizUserSelectedAnswers[];

  constructor(
    private submitQuizService: SubmitQuizService
  ) {

  }

  ngOnInit() {
    this.postQuizObject = this.submitQuizService.selectedAnswers;
  }

  public submitQuiz(): void {
    this.submitQuizService.submitQuizToServer(this.postQuizObject)
    .then(resp => {
      this.quizScores = resp;
    }).catch((err: HttpErrorResponse) => {
      alert(err.message);
    });
  }

}
