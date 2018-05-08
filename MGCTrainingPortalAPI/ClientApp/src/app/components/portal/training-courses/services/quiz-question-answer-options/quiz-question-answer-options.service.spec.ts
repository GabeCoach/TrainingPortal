import { TestBed, inject } from '@angular/core/testing';

import { QuizQuestionAnswerOptionsService } from './quiz-question-answer-options.service';

describe('QuizQuestionAnswerOptionsService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [QuizQuestionAnswerOptionsService]
    });
  });

  it('should be created', inject([QuizQuestionAnswerOptionsService], (service: QuizQuestionAnswerOptionsService) => {
    expect(service).toBeTruthy();
  }));
});
