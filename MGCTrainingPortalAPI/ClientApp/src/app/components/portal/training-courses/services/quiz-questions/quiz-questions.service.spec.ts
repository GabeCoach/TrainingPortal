import { TestBed, inject } from '@angular/core/testing';

import { QuizQuestionsService } from './quiz-questions.service';

describe('QuizQuestionsService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [QuizQuestionsService]
    });
  });

  it('should be created', inject([QuizQuestionsService], (service: QuizQuestionsService) => {
    expect(service).toBeTruthy();
  }));
});
