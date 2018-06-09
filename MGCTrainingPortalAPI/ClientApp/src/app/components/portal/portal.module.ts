import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OktaAuthModule, OktaCallbackComponent } from '@okta/okta-angular';

import { PortalRoutingModule } from './portal-routing.module';
import { PortalComponent } from './portal.component';
import { HomeComponent } from './home/home.component';
import { HeaderComponent } from './shared/header/header.component';
import { NavigationComponent } from './shared/navigation/navigation.component';
import { ChatSidebarComponent } from './shared/chat-sidebar/chat-sidebar.component';
import {ToasterModule, ToasterService} from 'angular2-toaster';


@NgModule({
  imports: [
    CommonModule,
    PortalRoutingModule,
    ToasterModule.forChild()
  ],
  declarations: [
    PortalComponent,
    HomeComponent,
    HeaderComponent,
    NavigationComponent,
    ChatSidebarComponent,
  ],
  providers: [
    ToasterService
  ]
})
export class PortalModule { }
