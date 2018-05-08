import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../../../services/base-service.service';
import { TrainingCourseModuleQuiz } from '../../models/training-course-module-quiz';

@Injectable()
export class TrainingCourseModuleQuizService {

  constructor(private http: HttpClient, private baseService: BaseService) { }

  public getTrainingCourseModuleQuizs(): Promise<any> {
    return this.http.get(this.baseService.BaseUrl + 'TrainingCourseModuleQuizs').toPromise();
  }

  public getTrainingCourseModuleQuizById(Id: number): Promise<any> {
    return this.http.get(this.baseService.BaseUrl + 'TrainingCourseModuleQuizs/' + Id).toPromise();
  }


  public postTrainingCourseModuleQuiz(trainingCourseModuleQuiz: TrainingCourseModuleQuiz): Promise<any> {
    return this.http.post(this.baseService.BaseUrl + 'TrainingCourseModuleQuizs', trainingCourseModuleQuiz).toPromise();
  }

  public updateTrainingCourseModule(trainingCourseModuleQuiz: TrainingCourseModuleQuiz, Id: number): Promise<any> {
    return this.http.put(this.baseService.BaseUrl + 'TrainingCourseModuleQuizs/' + Id, trainingCourseModuleQuiz).toPromise();
  }

  public deleteTrainingCourseModule(Id: number): Promise<any> {
    return this.http.delete(this.baseService.BaseUrl + 'TrainingCourseModuleQuizs/' + Id).toPromise();
  }

}
