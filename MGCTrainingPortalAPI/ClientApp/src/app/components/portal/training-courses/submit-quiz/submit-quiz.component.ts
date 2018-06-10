import { Component, OnInit } from '@angular/core';
import { QuizGrader } from '../models/quiz-grader';
import { SubmitQuizService } from '../services/submit-quiz/submit-quiz.service';
import { TrainingCourseQuizScores } from '../models/training-course-quiz-scores';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-submit-quiz',
  templateUrl: './submit-quiz.component.html',
  styleUrls: ['./submit-quiz.component.css']
})
export class SubmitQuizComponent implements OnInit {

  public quizScores: TrainingCourseQuizScores;

  constructor(
    private submitQuizService: SubmitQuizService
  ) { }

  ngOnInit() {
  }

  public submitQuiz(): void {
    this.submitQuizService.submitQuizToServer(this.submitQuizService.quiz)
    .then(resp => {
      this.quizScores = resp;
    }).catch((err: HttpErrorResponse) => {
      alert(err.message);
    });
  }

}
