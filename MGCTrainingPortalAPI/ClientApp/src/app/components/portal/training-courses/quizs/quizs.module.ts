import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { QuizsRoutingModule } from './quizs-routing.module';
import { QuizsComponent } from './quizs.component';
import { StartViewComponent } from './start-view/start-view.component';
import { QuestionsViewComponent } from './questions-view/questions-view.component';
import { ResultsViewComponent } from './results-view/results-view.component';

@NgModule({
  imports: [
    CommonModule,
    QuizsRoutingModule
  ],
  declarations: [
    QuizsComponent,
    StartViewComponent,
    QuestionsViewComponent,
    ResultsViewComponent
  ]
})
export class QuizsModule { }
