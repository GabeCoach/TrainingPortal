import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { OktaCallbackComponent, OktaAuthGuard } from '@okta/okta-angular';
import { HomeComponent } from './home/home.component';
import { PortalComponent } from './portal.component';
import { componentFactoryName } from '@angular/compiler';
import { QuizResultsComponent } from './quiz-results/quiz-results.component';
import { QuizResultDetailsComponent } from './quiz-result-details/quiz-result-details.component';

const routes: Routes = [
  { path: '', component: PortalComponent, children: [
      { path: 'home', component: HomeComponent, canActivate: [ OktaAuthGuard ], data: { onAuthRequired } },
      { path: 'training-courses', loadChildren: './training-courses/training-courses.module#TrainingCoursesModule', canActivate: [ OktaAuthGuard ], data: { preload: true, onAuthRequired } },
      { path: 'quiz-results', component: QuizResultsComponent, canActivate: [ OktaAuthGuard ], data: { preload: true, onAuthRequired } },
      { path: 'quiz-result-details/:id', component: QuizResultDetailsComponent, canActivate: [ OktaAuthGuard ], data: { preload: true, onAuthRequired } },
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
export class PortalRoutingModule { }
