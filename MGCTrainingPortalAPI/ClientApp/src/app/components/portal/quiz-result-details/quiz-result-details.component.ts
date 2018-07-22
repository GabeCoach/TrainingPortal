import { Component, OnInit } from '@angular/core';
import { QuizDetailsService } from '../services/quiz-details/quiz-details.service';
import { QuizDetails } from '../models/quiz-details';
import { ActivatedRoute } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-quiz-result-details',
  templateUrl: './quiz-result-details.component.html',
  styleUrls: ['./quiz-result-details.component.css']
})
export class QuizResultDetailsComponent implements OnInit {

  currentQuizDetails: any;
  quizSheetId: any;

  constructor(
    private quizDetailsService: QuizDetailsService,
    private route: ActivatedRoute
  ) { 
    this.quizSheetId = this.route.snapshot.paramMap.get('id');
  }

  ngOnInit() {
    this.quizDetailsService.getQuizDetails(this.quizSheetId)
      .then(resp => {
        this.currentQuizDetails = resp;
      }).catch((err:HttpErrorResponse) => {
        alert(err.message);
      })
  }

}
