import { TestBed, inject } from '@angular/core/testing';

import { TrainingCourseQuizScoresService } from './training-course-quiz-scores.service';

describe('TrainingCourseQuizScoresService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [TrainingCourseQuizScoresService]
    });
  });

  it('should be created', inject([TrainingCourseQuizScoresService], (service: TrainingCourseQuizScoresService) => {
    expect(service).toBeTruthy();
  }));
});
