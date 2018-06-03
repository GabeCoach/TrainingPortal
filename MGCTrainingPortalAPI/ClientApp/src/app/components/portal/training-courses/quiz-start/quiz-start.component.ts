import { Component, OnInit } from '@angular/core';
import { TrainingCourseModuleQuizService } from '../services/training-course-module-quiz/training-course-module-quiz.service';
import { TrainingCourseModuleQuiz } from '../models/training-course-module-quiz';
import { ToastrService } from 'ngx-toastr';
import { ParamMap, Router, ActivatedRoute } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-quiz-start',
  templateUrl: './quiz-start.component.html',
  styleUrls: ['./quiz-start.component.css']
})
export class QuizStartComponent implements OnInit {

  public trainingCourseModuleId: any;
  public trainingCourseModuleQuiz: TrainingCourseModuleQuiz;

  constructor(
    private trainingCourseModuleQuizService: TrainingCourseModuleQuizService,
    private toastrService: ToastrService,
    private route: ActivatedRoute
    ) {
      this.trainingCourseModuleId = this.route.snapshot.paramMap.get('id');
    }

  ngOnInit() {
    this.trainingCourseModuleQuizService.getTrainingCourseModuleQuizByModule(this.trainingCourseModuleId)
    .then(resp => {
      this.trainingCourseModuleQuiz = resp;
    }).catch( (err: HttpErrorResponse) => {
      this.toastrService.error(err.message, 'Error!');
    });
  }

}
