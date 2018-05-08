import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../../../services/base-service.service';
import { TrainingCourse } from '../../models/training-course';

@Injectable()
export class CourseBuilderService {

  constructor(private http: HttpClient, private baseService: BaseService) { }

  public getFullTrainingCourse(Id: number): Promise<any> {
    return this.http.get(this.baseService.BaseUrl + 'CourseBuilder/FullCourseMaterial/' + Id).toPromise();
  }



}
