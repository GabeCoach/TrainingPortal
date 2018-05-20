import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../../../services/base-service.service';
import { TrainingCourseModule } from '../../models/training-course-module';


@Injectable()
export class TrainingCourseModuleService {

  constructor(private http: HttpClient, private baseService: BaseService) { }

  public getTrainingCourseModules(): Promise<any> {
    return this.http.get(this.baseService.BaseUrl + 'TrainingCourseModules').toPromise();
  }

  public getTrainingCourseModuleById(Id: number): Promise<any> {
    return this.http.get(this.baseService.BaseUrl + 'TrainingCourseModules/' + Id).toPromise();
  }

  public getByTrainingCourseId(Id: number): Promise<any> {
    return this.http.get(this.baseService.BaseUrl + 'TrainingCourseModules/' + Id + '/Modules').toPromise();
  }

  public postTrainingCourseModule(trainingCourseModule: TrainingCourseModule): Promise<any> {
    return this.http.post(this.baseService.BaseUrl + 'TrainingCourseModules', TrainingCourseModule).toPromise();
  }

  public updateTrainingCourseModule(trainingCourseModule: TrainingCourseModule, Id: number): Promise<any> {
    return this.http.put(this.baseService.BaseUrl + 'TrainingCourseModules/' + Id, TrainingCourseModule).toPromise();
  }

  public deleteTrainingCourseModule(Id: number): Promise<any> {
    return this.http.delete(this.baseService.BaseUrl + 'TrainingCourseModules/' + Id).toPromise();
  }

}
