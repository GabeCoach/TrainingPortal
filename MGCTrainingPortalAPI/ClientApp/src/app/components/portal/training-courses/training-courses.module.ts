import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';

import { TrainingCoursesRoutingModule } from './training-courses-routing.module';
import { ModulesComponent } from './modules/modules.component';
import { TrainingCoursesComponent } from './training-courses.component';
import { CoursesComponent } from './courses/courses.component';

// Services
import { CourseBuilderService } from './services/course-builder/course-builder.service';
import { TrainingCourseService } from './services/training-course/training-course.service';

@NgModule({
  imports: [
    CommonModule,
    TrainingCoursesRoutingModule,
    HttpClientModule
  ],
  declarations: [
    TrainingCoursesComponent,
    ModulesComponent,
    CoursesComponent
  ],
  providers: [
    CourseBuilderService,
    TrainingCourseService
  ]

})
export class TrainingCoursesModule { }
