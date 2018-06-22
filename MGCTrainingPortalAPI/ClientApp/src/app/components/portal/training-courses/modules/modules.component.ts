// Base Imports
import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { CourseBuilderService } from '../services/course-builder/course-builder.service';
import { ParamMap, Router, ActivatedRoute, Route } from '@angular/router';


// Services
import { TrainingCourseService } from '../services/training-course/training-course.service';
import { TrainingCourseModuleService } from '../services/training-course-module/training-course-module.service';
import { BsModalService } from 'ngx-bootstrap/modal';
import { BsModalRef } from 'ngx-bootstrap/modal/bs-modal-ref.service';
import { TrainingCourseModuleSectionService } from '../services/training-course-module-section/training-course-module-section.service';
import { TrainingCourseModuleSubSectionService } from '../services/training-course-module-sub-section/training-course-module-sub-section.service';

// Models
import { TrainingCourse } from '../models/training-course';
import { TrainingCourseModule } from '../models/training-course-module';
import { TrainingCourseModuleSection } from '../models/training-course-module-section';

// Components
import { PageLoaderComponent } from '../../shared/page-loader/page-loader.component';



@Component({
  selector: 'app-modules',
  templateUrl: './modules.component.html',
  styleUrls: ['./modules.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class ModulesComponent implements OnInit {

  fullTrainingCourse: any;
  trainingCourseId: any;
  trainingCourseInformation: TrainingCourse;
  trainingCourseModule: TrainingCourseModule[] = [];
  bsModalRef: BsModalRef;
  courseModuleId: number;
  totalItems: number;
  currentPage: number;
  smallnumPages: number;


  constructor(
    private route: ActivatedRoute,
    private moduleService: TrainingCourseModuleService,
    private trainingCourseService: TrainingCourseService,
    private trainingCourseModuleSectionService: TrainingCourseModuleSectionService,
    private bsModalService: BsModalService,
    private router: Router
    ) {
    this.trainingCourseId = this.route.snapshot.paramMap.get('id');
  }

  ngOnInit() {
    this.moduleService.getByTrainingCourseId(this.trainingCourseId)
    .then(resp => {
      this.trainingCourseModule = resp;
    }).catch(err => {
      alert(err);
    });

    this.trainingCourseService.getTrainingCourseById(this.trainingCourseId)
    .then(resp => {
      this.trainingCourseInformation = resp;
    }).catch(err => {
      alert(err);
    });

  }

  public goToSectionsDisplay(id: number): void {

  }

}
