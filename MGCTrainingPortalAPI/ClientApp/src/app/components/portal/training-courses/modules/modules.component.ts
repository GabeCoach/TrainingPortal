// Base Imports
import { Component, OnInit } from '@angular/core';
import { CourseBuilderService } from '../services/course-builder/course-builder.service';
import { ParamMap, Router, ActivatedRoute } from '@angular/router';

// Services
import { TrainingCourseService } from '../services/training-course/training-course.service';
import { TrainingCourseModuleService } from '../services/training-course-module/training-course-module.service';

// Models
import { TrainingCourse } from '../models/training-course';
import { TrainingCourseModule } from '../models/training-course-module';

// Components
import { PageLoaderComponent } from '../../shared/page-loader/page-loader.component';



@Component({
  selector: 'app-modules',
  templateUrl: './modules.component.html',
  styleUrls: ['./modules.component.css']
})
export class ModulesComponent implements OnInit {

  fullTrainingCourse: any;
  trainingCourseId: any;
  trainingCourseInformation: TrainingCourse;
  trainingCourseModule: TrainingCourseModule[];

  constructor(
    private route: ActivatedRoute,
    private moduleService: TrainingCourseModuleService,
    private trainingCourseService: TrainingCourseService
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

}
