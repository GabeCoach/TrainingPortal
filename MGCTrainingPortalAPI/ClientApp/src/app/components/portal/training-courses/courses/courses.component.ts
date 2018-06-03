import { Component, OnInit } from '@angular/core';
import { TrainingCourseService } from '../services/training-course/training-course.service';
import { TrainingCourse } from '../models/training-course';
import { ToastrService } from 'ngx-toastr';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-courses',
  templateUrl: './courses.component.html',
  styleUrls: ['./courses.component.css']
})
export class CoursesComponent implements OnInit {

  public trainingCourses: TrainingCourse[];

  constructor(private trainingCourseService: TrainingCourseService, private toastrService: ToastrService) { }

  ngOnInit() {
    this.trainingCourseService.getTrainingCourses()
    .then(resp => {
      this.trainingCourses = resp;
    }).catch((err: HttpErrorResponse) => {
      this.toastrService.error(err.message, 'Error!');
    });
  }

}
