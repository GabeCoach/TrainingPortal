import { TestBed, inject } from '@angular/core/testing';

import { SubmitQuizService } from './submit-quiz.service';

describe('SubmitQuizService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [SubmitQuizService]
    });
  });

  it('should be created', inject([SubmitQuizService], (service: SubmitQuizService) => {
    expect(service).toBeTruthy();
  }));
});
