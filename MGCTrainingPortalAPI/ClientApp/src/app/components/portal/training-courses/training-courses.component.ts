import { Component, OnInit } from '@angular/core';
import { ValidatorService } from '../../../services/validator.service';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-training-courses',
  templateUrl: './training-courses.component.html',
  styleUrls: ['./training-courses.component.css']
})
export class TrainingCoursesComponent implements OnInit {

  constructor(
    private validator: ValidatorService
  ) { }

  ngOnInit() {
    this.validator.ValidateUser()
      .catch((err:HttpErrorResponse) => {
        this.validator.HandleValidationResult(err);
      });
  }

}
