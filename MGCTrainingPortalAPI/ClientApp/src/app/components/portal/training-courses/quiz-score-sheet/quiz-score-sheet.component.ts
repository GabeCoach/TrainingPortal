import { Component, OnInit } from '@angular/core';
import { TrainingCourseQuizScores } from '../models/training-course-quiz-scores';
import { TrainingCourseQuizScoresService } from '../services/training-course-quiz-scores/training-course-quiz-scores.service';

@Component({
  selector: 'app-quiz-score-sheet',
  templateUrl: './quiz-score-sheet.component.html',
  styleUrls: ['./quiz-score-sheet.component.css']
})
export class QuizScoreSheetComponent implements OnInit {

  public currentQuizScore: TrainingCourseQuizScores;

  constructor(
    private quizScoreService: TrainingCourseQuizScoresService
  ) { }

  ngOnInit() {
    this.currentQuizScore = this.quizScoreService.currentQuizScore;
  }

}
