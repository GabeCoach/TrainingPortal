import { TestBed, inject } from '@angular/core/testing';

import { CourseBuilderService } from './course-builder.service';

describe('CourseBuilderService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [CourseBuilderService]
    });
  });

  it('should be created', inject([CourseBuilderService], (service: CourseBuilderService) => {
    expect(service).toBeTruthy();
  }));
});
