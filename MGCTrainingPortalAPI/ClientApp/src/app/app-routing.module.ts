import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

// Components
import { LoginComponent } from './components/login/login.component';
import { OktaCallbackComponent, OktaAuthGuard } from '@okta/okta-angular';
import { LandingPageComponent } from './components/landing-page/landing-page.component';

export function onAuthRequired({ oktaAuth, router }) {
  // Redirect the user to your custom login page
  router.navigate(['/login']);
}

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'implicit/callback', component: OktaCallbackComponent },
  { path: 'landing-page', component: LandingPageComponent },
  { path: 'portal', loadChildren: './components/portal/portal.module#PortalModule',
  canActivate: [ OktaAuthGuard ], data: { preload: true, onAuthRequired }
  },
  { path: '', redirectTo: '/landing-page', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
