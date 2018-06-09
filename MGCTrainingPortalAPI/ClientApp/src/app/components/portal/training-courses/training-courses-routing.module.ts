import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TrainingCoursesComponent } from './training-courses.component';
import { CoursesComponent } from './courses/courses.component';
import { OktaAuthGuard } from '@okta/okta-angular';
import { ModulesComponent } from './modules/modules.component';
import { QuizStartComponent } from './quiz-start/quiz-start.component';
import { QuizInProgrssComponent } from './quiz-in-progrss/quiz-in-progrss.component';
import { SubmitQuizComponent } from './submit-quiz/submit-quiz.component';


const routes: Routes = [
    { path: '', component: TrainingCoursesComponent, children: [
      { path: 'courses', component: CoursesComponent, canActivate: [ OktaAuthGuard ], data: { onAuthRequired } },
      { path: 'modules/:id', component: ModulesComponent, canActivate: [ OktaAuthGuard ], data: { onAuthRequired } },
      // tslint:disable-next-line:max-line-length
      { path: 'quiz-start/:id', component: QuizStartComponent, canActivate: [ OktaAuthGuard ], data: { preload: true, onAuthRequired } },
      // tslint:disable-next-line:max-line-length
      { path: 'quiz-in-progress/:id', component: QuizInProgrssComponent, canActivate: [ OktaAuthGuard ], data: { preload: true, onAuthRequired } },
      { path: 'submit-quiz/:id', component: SubmitQuizComponent, canActivate: [ OktaAuthGuard ], data: { preload: true, onAuthRequired } },
      { path: '', redirectTo: '/training-courses/courses', pathMatch: 'full' }
    ]
  }
];

export function onAuthRequired({ oktaAuth, router }) {
  // Redirect the user to your custom login page
  router.navigate(['/login']);
}

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TrainingCoursesRoutingModule { }
