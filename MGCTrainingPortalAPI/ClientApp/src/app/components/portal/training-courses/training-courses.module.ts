import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';


// Services
import { TrainingCourseService } from './services/training-course/training-course.service';
import { TrainingCourseModuleSectionService } from './services/training-course-module-section/training-course-module-section.service';
import { TrainingCourseModuleQuizService } from './services/training-course-module-quiz/training-course-module-quiz.service';
// tslint:disable-next-line:max-line-length
import { TrainingCourseModuleSubSectionService } from './services/training-course-module-sub-section/training-course-module-sub-section.service';
import { QuizQuestionAnswerOptionsService } from './services/quiz-question-answer-options/quiz-question-answer-options.service';
import { QuizQuestionsService } from './services/quiz-questions/quiz-questions.service';
import { QuizInProgressService } from './services/quiz-in-progress/quiz-in-progress.service';
import { SubmitQuizService } from './services/submit-quiz/submit-quiz.service';
import { TrainingCourseQuizScoresService } from './services/training-course-quiz-scores/training-course-quiz-scores.service';

// Components
import { QuizStartComponent } from './quiz-start/quiz-start.component';
import { QuizInProgrssComponent } from './quiz-in-progrss/quiz-in-progrss.component';
import { TrainingCoursesRoutingModule } from './training-courses-routing.module';
import { CoursesComponent } from './courses/courses.component';
import { TrainingCoursesComponent } from './training-courses.component';
import { ModulesComponent } from './modules/modules.component';
import { SubmitQuizComponent } from './submit-quiz/submit-quiz.component';
import { QuizScoreSheetComponent } from './quiz-score-sheet/quiz-score-sheet.component';
import { SectionsDisplayComponent } from './sections-display/sections-display.component';
import { SubSectionsDisplayComponent } from './sub-sections-display/sub-sections-display.component';
import { AccordionModule } from 'ngx-bootstrap/accordion';

@NgModule({
  imports: [
    CommonModule,
    TrainingCoursesRoutingModule,
    FormsModule,
    AccordionModule.forRoot()
  ],
  declarations: [
    TrainingCoursesComponent,
    CoursesComponent,
    ModulesComponent,
    QuizStartComponent,
    QuizInProgrssComponent,
    SubmitQuizComponent,
    QuizScoreSheetComponent,
    SectionsDisplayComponent,
    SubSectionsDisplayComponent,
  ],
  providers: [
    TrainingCourseService,
    TrainingCourseModuleQuizService,
    QuizQuestionAnswerOptionsService,
    QuizQuestionsService,
    QuizInProgressService,
    SubmitQuizService,
    TrainingCourseQuizScoresService
  ]
})
export class TrainingCoursesModule { }
