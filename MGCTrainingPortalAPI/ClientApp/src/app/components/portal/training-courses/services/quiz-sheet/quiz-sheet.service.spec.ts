import { TestBed, inject } from '@angular/core/testing';

import { QuizSheetService } from './quiz-sheet.service';

describe('QuizSheetService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [QuizSheetService]
    });
  });

  it('should be created', inject([QuizSheetService], (service: QuizSheetService) => {
    expect(service).toBeTruthy();
  }));
});
