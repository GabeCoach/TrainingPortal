import { TestBed, inject } from '@angular/core/testing';

import { TrainingCourseService } from './training-course.service';

describe('TrainingCourseService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [TrainingCourseService]
    });
  });

  it('should be created', inject([TrainingCourseService], (service: TrainingCourseService) => {
    expect(service).toBeTruthy();
  }));
});
