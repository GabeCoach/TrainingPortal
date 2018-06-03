import { TestBed, inject } from '@angular/core/testing';

import { TrainingCourseModuleService } from './training-course-module.service';

describe('TrainingCourseModuleService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [TrainingCourseModuleService]
    });
  });

  it('should be created', inject([TrainingCourseModuleService], (service: TrainingCourseModuleService) => {
    expect(service).toBeTruthy();
  }));
});
