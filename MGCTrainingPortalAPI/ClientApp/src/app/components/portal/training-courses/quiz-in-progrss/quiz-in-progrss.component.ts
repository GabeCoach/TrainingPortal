import { Component, OnInit, ViewChild } from '@angular/core';
import { ToasterService } from 'angular2-toaster';
import { ParamMap, Router, ActivatedRoute } from '@angular/router';
import { HttpErrorResponse, HttpResponse } from '@angular/common/http';
import { QuizQuestionsService } from '../services/quiz-questions/quiz-questions.service';
import { QuizQuestionAnswerOptionsService } from '../services/quiz-question-answer-options/quiz-question-answer-options.service';
import { QuizQuestions } from '../models/quiz-questions';
import { QuizQuestionAnswerOptions } from '../models/quiz-question-answer-options';
import { QuizUserSelectedAnswers } from '../models/quiz-user-selected-answers';
import { NgForm } from '@angular/forms';
import { SubmitQuizService } from '../services/submit-quiz/submit-quiz.service';
import { QuizSheetService } from '../services/quiz-sheet/quiz-sheet.service';
import { ValidatorService } from '../../../../services/validator.service';

@Component({
  selector: 'app-quiz-in-progrss',
  templateUrl: './quiz-in-progrss.component.html',
  styleUrls: ['./quiz-in-progrss.component.css']
})
export class QuizInProgrssComponent implements OnInit {

  private trainingCourseModuleQuizId: any;
  private quizQuestions: QuizQuestions[];
  public activeQuizQuestion: QuizQuestions;
  private questionCount = 0;
  public quizQuestionAnswerOptions: QuizQuestionAnswerOptions[];
  public selectedAnswers: QuizUserSelectedAnswers[] = [];
  @ViewChild('answerOptionsForm') form: any;

  constructor(
    private quizQuestionService: QuizQuestionsService,
    private quizQuestionAnswerOptionsService: QuizQuestionAnswerOptionsService,
    private route: ActivatedRoute,
    private router: Router,
    private toasterService: ToasterService,
    private submitQuizService: SubmitQuizService,
    private quizSheetService: QuizSheetService,
    private validator: ValidatorService
  ) {
    this.trainingCourseModuleQuizId = this.route.snapshot.paramMap.get('id');
    this.quizQuestions = [];
    this.quizQuestionAnswerOptions = [];
    this.activeQuizQuestion = new QuizQuestions; 
  }

  ngOnInit() {
    this.validator.ValidateUser()
      .catch((err:HttpErrorResponse) => {
        this.validator.HandleValidationResult(err);
      });

    this.quizQuestionService.getQuizQuestionsByModuleQuiz(this.trainingCourseModuleQuizId)
    .then(resp => {
      this.quizQuestions = resp;
      this.iterateQuizQuestion(this.quizQuestions);
    }).catch((err: HttpErrorResponse) => {

    });
  }

  private iterateQuizQuestion(quizQuestions: QuizQuestions[]): void {
    this.activeQuizQuestion = quizQuestions[this.questionCount];

    this.quizQuestionAnswerOptionsService.getQuizQuestionAnswerOptionByQuestion(this.activeQuizQuestion.Id)
    .then(resp => {
      this.quizQuestionAnswerOptions = resp;
    }).catch((err: HttpErrorResponse) => {

    });

    this.questionCount++;
  }

  public nextQuestion(): void {
    if (this.form.value.selectedAnswer === null || this.form.value.selectedAnswer === undefined || this.form.value.selectedAnswer === '') {
      this.toasterService.popAsync('warning', '', 'Please select an answer.');
    } else {

      if (this.quizQuestions.length <= this.questionCount) {
        let answer: QuizUserSelectedAnswers = new QuizUserSelectedAnswers;

        answer.quiz_answer_option_id = this.form.value.selectedAnswer;
        answer.quiz_sheet_id = this.quizSheetService.currentQuizSheetId;
        answer.quiz_question_id = this.activeQuizQuestion.Id;
        this.selectedAnswers.push(answer);

        this.submitQuizService.addSelectedAnswers(this.selectedAnswers);
        this.router.navigate([`/training-courses/submit-quiz/${this.trainingCourseModuleQuizId}`]);
      } else if (this.quizQuestions.length > this.questionCount) {
        // tslint:disable-next-line:prefer-const
        let answer: QuizUserSelectedAnswers = new QuizUserSelectedAnswers;

        answer.quiz_answer_option_id = this.form.value.selectedAnswer;
        answer.quiz_sheet_id = this.quizSheetService.currentQuizSheetId;
        answer.quiz_question_id = this.activeQuizQuestion.Id;

        this.selectedAnswers.push(answer);
        this.iterateQuizQuestion(this.quizQuestions);
      }

    }
  }

  public submitQuiz(): void {

  }

}
