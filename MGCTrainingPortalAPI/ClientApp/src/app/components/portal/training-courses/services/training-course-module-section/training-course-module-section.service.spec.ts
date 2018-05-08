import { TestBed, inject } from '@angular/core/testing';

import { TrainingCourseModuleSectionService } from './training-course-module-section.service';

describe('TrainingCourseModuleSectionService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [TrainingCourseModuleSectionService]
    });
  });

  it('should be created', inject([TrainingCourseModuleSectionService], (service: TrainingCourseModuleSectionService) => {
    expect(service).toBeTruthy();
  }));
});
