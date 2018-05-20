// Modules

import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { OktaAuthModule, OktaCallbackComponent } from '@okta/okta-angular';
import { PortalModule } from './components/portal/portal.module';
import { HttpClientModule } from '@angular/common/http';

// Components
import { AppComponent } from './app.component';
import { LoginComponent } from './components/login/login.component';
import { LandingPageComponent } from './components/landing-page/landing-page.component';
import { FooterComponent } from './components/portal/shared/footer/footer.component';
import { PageLoaderComponent } from './components/portal/shared/page-loader/page-loader.component';


// Services
import { AuthService } from './services/auth.service';
import { BaseService } from './services/base-service.service';

// Enums
import { AuthConfig } from './enums/auth-config.enum';

// HTTP
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthInterceptor } from './services/auth-interceptor.service';


// Auth Configuration for Okta Sign-in Widget
const config = {
  issuer: AuthConfig.ISSUER,
  redirectUri: AuthConfig.DEV_REDIRECT_URI,
  clientId: AuthConfig.CLIENT_ID
};


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    LandingPageComponent,
    FooterComponent,
    PageLoaderComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    PortalModule,
    OktaAuthModule.initAuth(config)
  ],
  providers: [
    AuthService,
    BaseService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
