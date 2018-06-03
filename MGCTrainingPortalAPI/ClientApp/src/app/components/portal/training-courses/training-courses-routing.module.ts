import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TrainingCoursesComponent } from './training-courses.component';
import { ModulesComponent } from './modules/modules.component';
import { CoursesComponent } from './courses/courses.component';
import { OktaCallbackComponent, OktaAuthGuard } from '@okta/okta-angular';

const routes: Routes = [
  {
    path: '', component: TrainingCoursesComponent, children: [
      { path: 'modules/:id', component: ModulesComponent, canActivate: [ OktaAuthGuard ], data: { onAuthRequired } },
      { path: 'courses', component: CoursesComponent, canActivate: [ OktaAuthGuard ], data: { onAuthRequired } },
      { path: '', redirectTo: '/training-courses/courses', pathMatch: 'full'}
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
