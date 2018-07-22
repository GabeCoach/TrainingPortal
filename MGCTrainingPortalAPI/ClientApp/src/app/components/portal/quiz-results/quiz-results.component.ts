import { Component, OnInit } from '@angular/core';
import { TrainingCourseQuizScoresService } from '../training-courses/services/training-course-quiz-scores/training-course-quiz-scores.service';
import { UsersService } from '../services/user/users.service';
import { TrainingCourseQuizScores } from '../training-courses/models/training-course-quiz-scores';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-quiz-results',
  templateUrl: './quiz-results.component.html',
  styleUrls: ['./quiz-results.component.css']
})
export class QuizResultsComponent implements OnInit {

  public userQuizScores: TrainingCourseQuizScores[] = [];

  constructor(
    private quizScoreService: TrainingCourseQuizScoresService,
    private usersService: UsersService
  ) { }

  ngOnInit() {
    this.quizScoreService.getScoresByUser(this.usersService.currentUser.Id)
      .then(resp => {
        this.userQuizScores = resp;
      }).catch((err:HttpErrorResponse) => {
        alert(err.message);
      })
  }

}
