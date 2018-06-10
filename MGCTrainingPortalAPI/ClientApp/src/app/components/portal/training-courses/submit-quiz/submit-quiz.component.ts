import { Component, OnInit } from '@angular/core';
import { QuizGrader } from '../models/quiz-grader';
import { SubmitQuizService } from '../services/submit-quiz/submit-quiz.service';

@Component({
  selector: 'app-submit-quiz',
  templateUrl: './submit-quiz.component.html',
  styleUrls: ['./submit-quiz.component.css']
})
export class SubmitQuizComponent implements OnInit {

  constructor(
    private submitQuizService: SubmitQuizService
  ) { }

  ngOnInit() {
  }

  public submitQuiz(): void {
    this.submitQuizService.submitQuizToServer(this.submitQuizService.quiz);
  }

}
