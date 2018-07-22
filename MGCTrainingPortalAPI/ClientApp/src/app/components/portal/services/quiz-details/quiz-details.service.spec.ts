import { TestBed, inject } from '@angular/core/testing';

import { QuizDetailsService } from './quiz-details.service';

describe('QuizDetailsService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [QuizDetailsService]
    });
  });

  it('should be created', inject([QuizDetailsService], (service: QuizDetailsService) => {
    expect(service).toBeTruthy();
  }));
});
