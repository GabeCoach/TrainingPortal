import { Component, OnInit } from '@angular/core';
import { TrainingCourseService } from '../services/training-course/training-course.service';
import { TrainingCourse } from '../models/training-course';
import { ToasterService } from 'angular2-toaster';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-courses',
  templateUrl: './courses.component.html',
  styleUrls: ['./courses.component.css']
})
export class CoursesComponent implements OnInit {

  public trainingCourses: TrainingCourse[];

  constructor(private trainingCourseService: TrainingCourseService, private toasterService: ToasterService) { }

  ngOnInit() {
    this.trainingCourseService.getTrainingCourses()
    .then(resp => {
      this.trainingCourses = resp;
    }).catch((err: HttpErrorResponse) => {
      this.toasterService.popAsync('error', 'Error', err.message);
    });
  }

}
