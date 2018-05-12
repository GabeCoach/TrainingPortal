// Base Imports
import { Component, OnInit } from '@angular/core';
import { CourseBuilderService } from '../services/course-builder/course-builder.service';
import { ParamMap, Router, ActivatedRoute } from '@angular/router';

// Services
import { TrainingCourseService } from '../services/training-course/training-course.service';

// Models
import { TrainingCourse } from '../models/training-course';
import { TrainingCourseModule } from '../models/training-course-module';



@Component({
  selector: 'app-modules',
  templateUrl: './modules.component.html',
  styleUrls: ['./modules.component.css']
})
export class ModulesComponent implements OnInit {

  fullTrainingCourse: any;
  trainingCourseId: any;
  trainingCourseInformation: TrainingCourse;
  trainingCourseModule: Array<TrainingCourseModule>;

  constructor(private courseBuilderService: CourseBuilderService, private route: ActivatedRoute) {
    this.trainingCourseId = this.route.snapshot.paramMap.get('id');
  }

  ngOnInit() {
    this.courseBuilderService.getFullTrainingCourse(this.trainingCourseId)
    .then(resp => {
      this.fullTrainingCourse = resp;
      this.trainingCourseInformation = this.fullTrainingCourse.training_course_information;
      this.trainingCourseModule = this.fullTrainingCourse.training_course_modules;

    }).catch(err => {
      alert(err);
    });

  }

}
