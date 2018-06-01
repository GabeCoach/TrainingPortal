import { Component, OnInit } from '@angular/core';
import { TrainingCourseService } from '../services/training-course/training-course.service';
import { TrainingCourse } from '../models/training-course';

@Component({
  selector: 'app-courses',
  templateUrl: './courses.component.html',
  styleUrls: ['./courses.component.css']
})
export class CoursesComponent implements OnInit {

  constructor(private trainingCourseService: TrainingCourseService) { }

  public trainingCourses: TrainingCourse[];

  ngOnInit() {
    this.trainingCourseService.getTrainingCourses()
    .then(resp => {
      this.trainingCourses = resp;
      this.trainingCourseService.trainingCourseId = this.trainingCourses[0].Id;
    }).catch(err => {
      console.log(JSON.stringify(err.message));
    });
  }



}
