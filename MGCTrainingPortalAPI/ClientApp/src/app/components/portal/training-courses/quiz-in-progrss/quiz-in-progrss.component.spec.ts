import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { QuizInProgrssComponent } from './quiz-in-progrss.component';

describe('QuizInProgrssComponent', () => {
  let component: QuizInProgrssComponent;
  let fixture: ComponentFixture<QuizInProgrssComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ QuizInProgrssComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(QuizInProgrssComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
