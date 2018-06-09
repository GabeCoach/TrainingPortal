import { TestBed, inject } from '@angular/core/testing';

import { QuizInProgressService } from './quiz-in-progress.service';

describe('QuizInProgressService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [QuizInProgressService]
    });
  });

  it('should be created', inject([QuizInProgressService], (service: QuizInProgressService) => {
    expect(service).toBeTruthy();
  }));
});
