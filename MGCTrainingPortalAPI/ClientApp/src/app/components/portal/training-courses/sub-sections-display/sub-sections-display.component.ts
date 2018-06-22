import { Component, OnInit } from '@angular/core';
import { TrainingCourseModuleSubSectionService } from '../services/training-course-module-sub-section/training-course-module-sub-section.service';
import { TrainingCourseModuleSubSection } from '../models/training-course-module-sub-section';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';
import { TrainingCourseModuleSectionService } from '../services/training-course-module-section/training-course-module-section.service';
import { TrainingCourseModuleSection } from '../models/training-course-module-section';

@Component({
  selector: 'app-sub-sections-display',
  templateUrl: './sub-sections-display.component.html',
  styleUrls: ['./sub-sections-display.component.css']
})
export class SubSectionsDisplayComponent implements OnInit {

  public subSections: TrainingCourseModuleSubSection;
  private moduleSectionId: any;
  public currentModuleSection: TrainingCourseModuleSection;

  constructor(
    private subSectionService: TrainingCourseModuleSubSectionService,
    private moduleSectionService: TrainingCourseModuleSectionService,
    private route: ActivatedRoute,
    private router: Router
  ) { 
    this.moduleSectionId = this.route.snapshot.paramMap.get('id');
  }

  ngOnInit() {
    this.subSectionService.getModuleSubSectionByModuleSection(this.moduleSectionId)
    .then(resp => {
      this.subSections = resp;
    }).catch((err: HttpErrorResponse) => {
      alert(err.message);
    })

    this.moduleSectionService.getTrainingCourseModuleSectionById(this.moduleSectionId)
    .then(resp => {
      this.currentModuleSection = resp;
    }).catch((err: HttpErrorResponse) => {
      alert(err.message);
    })
  }

}
