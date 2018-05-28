import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TrainingCoursesComponent } from './training-courses.component';
import { ModulesComponent } from './modules/modules.component';
import { CoursesComponent } from './courses/courses.component';
import { QuizsComponent } from './quizs/quizs.component';

const routes: Routes = [
  {
    path: '', component: TrainingCoursesComponent, children: [
      { path: 'modules/:id', component: ModulesComponent },
      { path: 'courses', component: CoursesComponent },
      { path: 'quiz/:id', component: QuizsComponent},
      { path: '', redirectTo: '/training-courses/courses', pathMatch: 'full'}
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TrainingCoursesRoutingModule { }
