import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../../../services/base-service.service';
import { TrainingCourse } from '../../models/training-course';

@Injectable()
export class TrainingCourseService {

  public trainingCourseId: number;

  constructor(private http: HttpClient, private baseService: BaseService) { }

  public async getTrainingCourses(): Promise<any> {
    return await this.http.get(this.baseService.BaseUrl + 'TrainingCourses', {responseType: 'json'}).toPromise();
  }

  public async getTrainingCourseById(Id: number): Promise<any> {
    return await this.http.get(this.baseService.BaseUrl + 'TrainingCourses/' + Id).toPromise();
  }


  public async postTrainingCourse(trainingCourse: TrainingCourse): Promise<any> {
    return await this.http.post(this.baseService.BaseUrl + 'TrainingCourses', trainingCourse).toPromise();
  }

  public async updateTrainingCourse(trainingCourse: TrainingCourse, Id: number): Promise<any> {
    return await this.http.put(this.baseService.BaseUrl + 'TrainingCourses/' + Id, trainingCourse).toPromise();
  }

  public async deleteTrainingCourse(Id: number): Promise<any> {
    return await this.http.delete(this.baseService.BaseUrl + 'TrainingCourses/' + Id).toPromise();
  }
}
