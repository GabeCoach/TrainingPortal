import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../../../services/base-service.service';
import { TrainingCourse } from '../../models/training-course';
import { OktaAuthService } from '@okta/okta-angular';
import { HttpHeaders } from '@angular/common/http';

@Injectable()
export class CourseBuilderService {

  constructor(private http: HttpClient, private baseService: BaseService, private oktaAuth: OktaAuthService) { }

  public getFullTrainingCourse(Id: number): Promise<any> {
    return this.http.get(this.baseService.BaseUrl + 'CourseBuilder/FullCourseMaterial/' + Id).toPromise();
  }



}
