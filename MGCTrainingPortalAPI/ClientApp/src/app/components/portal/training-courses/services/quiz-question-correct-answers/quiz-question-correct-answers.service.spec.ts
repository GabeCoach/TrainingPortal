import { TestBed, inject } from '@angular/core/testing';

import { QuizQuestionCorrectAnswersService } from './quiz-question-correct-answers.service';

describe('QuizQuestionCorrectAnswersService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [QuizQuestionCorrectAnswersService]
    });
  });

  it('should be created', inject([QuizQuestionCorrectAnswersService], (service: QuizQuestionCorrectAnswersService) => {
    expect(service).toBeTruthy();
  }));
});
