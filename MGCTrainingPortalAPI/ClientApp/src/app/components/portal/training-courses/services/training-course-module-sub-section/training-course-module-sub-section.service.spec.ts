import { TestBed, inject } from '@angular/core/testing';

import { TrainingCourseModuleSubSectionService } from './training-course-module-sub-section.service';

describe('TrainingCourseModuleSubSectionService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [TrainingCourseModuleSubSectionService]
    });
  });

  it('should be created', inject([TrainingCourseModuleSubSectionService], (service: TrainingCourseModuleSubSectionService) => {
    expect(service).toBeTruthy();
  }));
});
