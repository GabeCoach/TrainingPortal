import { Component, OnInit } from '@angular/core';
import { TrainingCourseQuizScores } from '../models/training-course-quiz-scores';
import { TrainingCourseQuizScoresService } from '../services/training-course-quiz-scores/training-course-quiz-scores.service';
import { ValidatorService } from '../../../../services/validator.service';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-quiz-score-sheet',
  templateUrl: './quiz-score-sheet.component.html',
  styleUrls: ['./quiz-score-sheet.component.css']
})
export class QuizScoreSheetComponent implements OnInit {

  public currentQuizScore: TrainingCourseQuizScores;

  constructor(
    private quizScoreService: TrainingCourseQuizScoresService,
    private validator: ValidatorService
  ) { }

  ngOnInit() {
    this.validator.ValidateUser()
    .catch((err:HttpErrorResponse) => {
      this.validator.HandleValidationResult(err);
    });

    this.currentQuizScore = this.quizScoreService.currentQuizScore;
  }

}
