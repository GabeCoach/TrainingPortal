// Modules
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { OktaAuthModule, OktaCallbackComponent } from '@okta/okta-angular';
import { PortalModule } from './components/portal/portal.module';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';


// ngx-bootstrap modules
import { ModalModule } from 'ngx-bootstrap/modal';
import { AccordionModule } from 'ngx-bootstrap/accordion';
import { PaginationModule } from 'ngx-bootstrap/pagination';


// Components
import { AppComponent } from './app.component';
import { LoginComponent } from './components/login/login.component';
import { LandingPageComponent } from './components/landing-page/landing-page.component';
import { FooterComponent } from './components/portal/shared/footer/footer.component';
import { PageLoaderComponent } from './components/portal/shared/page-loader/page-loader.component';

// Services
import { AuthService } from './services/auth.service';
import { BaseService } from './services/base-service.service';
import { TrainingCourseModuleService } from './components/portal/training-courses/services/training-course-module/training-course-module.service';
import { TrainingCourseModuleSectionService } from './components/portal/training-courses/services/training-course-module-section/training-course-module-section.service';
import { TrainingCourseModuleSubSectionService } from './components/portal/training-courses/services/training-course-module-sub-section/training-course-module-sub-section.service';
// Enums
import { AuthConfig } from './enums/auth-config.enum';

// HTTP
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthInterceptor } from './services/auth-interceptor.service';

// Auth Configuration for Okta Sign-in Widget
const config = {
  issuer: AuthConfig.ISSUER,
  redirectUri: AuthConfig.PROD_REDIRECT_URI_HTTPS,
  clientId: AuthConfig.CLIENT_ID
};

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    LandingPageComponent,
    FooterComponent,
    PageLoaderComponent,
  ],
  entryComponents: [

  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    ModalModule.forRoot(),
    PaginationModule.forRoot(),
    PortalModule,
    OktaAuthModule.initAuth(config),
    BrowserAnimationsModule
  ],
  providers: [
    AuthService,
    BaseService,
    TrainingCourseModuleSectionService,
    TrainingCourseModuleSubSectionService,
    TrainingCourseModuleService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
