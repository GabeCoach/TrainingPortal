import { TestBed, inject } from '@angular/core/testing';

import { TrainingCourseModuleQuizService } from './training-course-module-quiz.service';

describe('TrainingCourseModuleQuizService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [TrainingCourseModuleQuizService]
    });
  });

  it('should be created', inject([TrainingCourseModuleQuizService], (service: TrainingCourseModuleQuizService) => {
    expect(service).toBeTruthy();
  }));
});
