import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../../../services/base-service.service';
import { TrainingCourseModule } from '../../models/training-course-module';


@Injectable()
export class TrainingCourseModuleService {

  public selectedTrainingCourseModule: TrainingCourseModule;

  constructor(private http: HttpClient, private baseService: BaseService) { }

  public async getTrainingCourseModules(): Promise<any> {
    return await this.http.get(this.baseService.BaseUrl + 'TrainingCourseModules').toPromise();
  }

  public async getTrainingCourseModuleById(Id: number): Promise<any> {
    return await this.http.get(this.baseService.BaseUrl + 'TrainingCourseModules/' + Id).toPromise();
  }

  public async getByTrainingCourseId(Id: number): Promise<any> {
    return await this.http.get(this.baseService.BaseUrl + 'TrainingCourseModules/' + Id + '/Modules').toPromise();
  }

  public async postTrainingCourseModule(trainingCourseModule: TrainingCourseModule): Promise<any> {
    return await this.http.post(this.baseService.BaseUrl + 'TrainingCourseModules', trainingCourseModule).toPromise();
  }

  public async updateTrainingCourseModule(trainingCourseModule: TrainingCourseModule, Id: number): Promise<any> {
    return await this.http.put(this.baseService.BaseUrl + 'TrainingCourseModules/' + Id, trainingCourseModule).toPromise();
  }

  public async deleteTrainingCourseModule(Id: number): Promise<any> {
    return await this.http.delete(this.baseService.BaseUrl + 'TrainingCourseModules/' + Id).toPromise();
  }

}
