import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { QuizResultDetailsComponent } from './quiz-result-details.component';

describe('QuizResultDetailsComponent', () => {
  let component: QuizResultDetailsComponent;
  let fixture: ComponentFixture<QuizResultDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ QuizResultDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(QuizResultDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
