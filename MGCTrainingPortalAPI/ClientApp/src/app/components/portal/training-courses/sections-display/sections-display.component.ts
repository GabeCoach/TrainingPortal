import { Component, OnInit } from '@angular/core';
import { TrainingCourseModuleSectionService } from '../services/training-course-module-section/training-course-module-section.service';
import { TrainingCourseModuleSection } from '../models/training-course-module-section';
import { TrainingCourseModuleService } from '../services/training-course-module/training-course-module.service';
import { TrainingCourseModule } from '../models/training-course-module';
import { Router, ActivatedRoute, } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-sections-display',
  templateUrl: './sections-display.component.html',
  styleUrls: ['./sections-display.component.css']
})
export class SectionsDisplayComponent implements OnInit {

  public moduleSections: TrainingCourseModuleSection;
  public courseModuleId: any;
  public currentCourseModule: TrainingCourseModule;

  constructor(
    private moduleSectionService: TrainingCourseModuleSectionService,
    private route: ActivatedRoute,
    private router: Router,
    private courseModuleService: TrainingCourseModuleService
  ) { 
    this.courseModuleId = this.route.snapshot.paramMap.get('id');
  }

  ngOnInit() {
    this.courseModuleService.getTrainingCourseModuleById(this.courseModuleId)
    .then(resp => {
      this.currentCourseModule = resp;
    }).catch((err: HttpErrorResponse) => {
      alert(err.message)
    });

    this.moduleSectionService.getTrainingCourseModuleSectionByModule(this.courseModuleId)
    .then(resp => {
      this.moduleSections = resp;
    }).catch((err: HttpErrorResponse) => {
      alert(err.message);
    })
  }

}
