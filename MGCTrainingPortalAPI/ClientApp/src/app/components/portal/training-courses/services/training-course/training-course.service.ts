import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../../../services/base-service.service';
import { TrainingCourse } from '../../models/training-course';

@Injectable()
export class TrainingCourseService {

  public trainingCourseId: number;

  constructor(private http: HttpClient, private baseService: BaseService) { }

  public getTrainingCourses(): Promise<any> {
    return this.http.get(this.baseService.BaseUrl + 'TrainingCourses').toPromise();
  }

  public getTrainingCourseById(Id: number): Promise<any> {
    return this.http.get(this.baseService.BaseUrl + 'TrainingCourses/' + Id).toPromise();
  }


  public postTrainingCourse(trainingCourse: TrainingCourse): Promise<any> {
    return this.http.post(this.baseService.BaseUrl + 'TrainingCourses', trainingCourse).toPromise();
  }

  public updateTrainingCourse(trainingCourse: TrainingCourse, Id: number): Promise<any> {
    return this.http.put(this.baseService.BaseUrl + 'TrainingCourses/' + Id, trainingCourse).toPromise();
  }

  public deleteTrainingCourse(Id: number): Promise<any> {
    return this.http.delete(this.baseService.BaseUrl + 'TrainingCourses/' + Id).toPromise();
  }
}
