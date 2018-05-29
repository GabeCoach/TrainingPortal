import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

// components
import { StartViewComponent } from './start-view/start-view.component';
import { QuestionsViewComponent } from './questions-view/questions-view.component';
import { ResultsViewComponent } from './results-view/results-view.component';
import { QuizsComponent } from './quizs.component';
import { OktaCallbackComponent, OktaAuthGuard } from '@okta/okta-angular';

const routes: Routes = [
  { path: '', component: QuizsComponent, children: [
      { path: 'start-quiz', component: StartViewComponent, canActivate: [ OktaAuthGuard ], data: { onAuthRequired } },
      { path: 'quiz-questions', component: QuestionsViewComponent, canActivate: [ OktaAuthGuard ], data: { onAuthRequired } },
      { path: 'quiz-results', component: ResultsViewComponent, canActivate: [ OktaAuthGuard ], data: { onAuthRequired } },
      { path: '', redirectTo: '/training-courses/quiz/start-quiz', pathMatch: 'full' }
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
export class QuizsRoutingModule { }
