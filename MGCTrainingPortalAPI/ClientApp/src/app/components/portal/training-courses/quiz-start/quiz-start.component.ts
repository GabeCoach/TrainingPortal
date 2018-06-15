import { Component, OnInit } from '@angular/core';
import { TrainingCourseModuleQuizService } from '../services/training-course-module-quiz/training-course-module-quiz.service';
import { TrainingCourseModuleQuiz } from '../models/training-course-module-quiz';
import { ToasterService } from 'angular2-toaster';
import { ParamMap, Router, ActivatedRoute } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';
import { QuizSheetService } from '../services/quiz-sheet/quiz-sheet.service';
import { QuizSheet } from '../models/quiz-sheet';
import { SubmitQuizService } from '../services/submit-quiz/submit-quiz.service';

@Component({
  selector: 'app-quiz-start',
  templateUrl: './quiz-start.component.html',
  styleUrls: ['./quiz-start.component.css']
})
export class QuizStartComponent implements OnInit {

  private trainingCourseModuleId: any;
  public trainingCourseModuleQuiz: TrainingCourseModuleQuiz;
  private quizSheet: QuizSheet;

  constructor(
    private trainingCourseModuleQuizService: TrainingCourseModuleQuizService,
    private toasterService: ToasterService,
    private route: ActivatedRoute,
    private router: Router,
    private quizSheetService: QuizSheetService,
    private submitQuizService: SubmitQuizService
    ) {
      this.trainingCourseModuleId = this.route.snapshot.paramMap.get('id');
    }

  ngOnInit() {
    this.trainingCourseModuleQuizService.getTrainingCourseModuleQuizByModule(this.trainingCourseModuleId)
    .then(resp => {
      this.trainingCourseModuleQuiz = resp;
    }).catch( (err: HttpErrorResponse) => {
      this.toasterService.popAsync('error', 'Error!', err.message);
    });
  }

  public startQuiz(QuizId: number): void {
    this.quizSheet = new QuizSheet;
    this.quizSheet.quiz_id = QuizId;
    this.submitQuizService.addQuizSheet(this.quizSheet);

    this.quizSheetService.submitQuizSheet(this.quizSheet)
    .then(resp => {
      this.quizSheetService.currentQuizSheetId = resp.Id;
      this.router.navigate([`/training-courses/quiz-in-progress/${QuizId}`]);
    }).catch((err: HttpErrorResponse) => {
      alert(err.message);
    });
  }

}
