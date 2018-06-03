import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TrainingCoursesRoutingModule } from './training-courses-routing.module';
import { CoursesComponent } from './courses/courses.component';
import { TrainingCoursesComponent } from './training-courses.component';
import { ModulesComponent } from './modules/modules.component';

// Services
import { TrainingCourseService } from './services/training-course/training-course.service';
import { TrainingCourseModuleService } from './services/training-course-module/training-course-module.service';
import { TrainingCourseModuleSectionService } from './services/training-course-module-section/training-course-module-section.service';
import { TrainingCourseModuleQuizService } from './services/training-course-module-quiz/training-course-module-quiz.service';
// tslint:disable-next-line:max-line-length
import { TrainingCourseModuleSubSectionService } from './services/training-course-module-sub-section/training-course-module-sub-section.service';
import { QuizStartComponent } from './quiz-start/quiz-start.component';

@NgModule({
  imports: [
    CommonModule,
    TrainingCoursesRoutingModule
  ],
  declarations: [
    TrainingCoursesComponent,
    CoursesComponent,
    ModulesComponent,
    QuizStartComponent
  ],
  providers: [
    TrainingCourseService,
    TrainingCourseModuleService,
    TrainingCourseModuleQuizService
  ]
})
export class TrainingCoursesModule { }
