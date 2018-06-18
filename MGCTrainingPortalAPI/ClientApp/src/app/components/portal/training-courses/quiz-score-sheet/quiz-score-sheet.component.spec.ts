import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { QuizScoreSheetComponent } from './quiz-score-sheet.component';

describe('QuizScoreSheetComponent', () => {
  let component: QuizScoreSheetComponent;
  let fixture: ComponentFixture<QuizScoreSheetComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ QuizScoreSheetComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(QuizScoreSheetComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
