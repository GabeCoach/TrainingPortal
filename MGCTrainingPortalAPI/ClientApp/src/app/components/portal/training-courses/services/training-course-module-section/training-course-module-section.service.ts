import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../../../services/base-service.service';
import { TrainingCourseModuleSection } from '../../models/training-course-module-section';


@Injectable()
export class TrainingCourseModuleSectionService {

  trainingCourseModuleId: number;

  constructor(private http: HttpClient, private baseService: BaseService) { }

  public async getTrainingCourseModuleSections(): Promise<any> {
    return await this.http.get(this.baseService.BaseUrl + 'TrainingCourseModuleSections').toPromise();
  }

  public async getTrainingCourseModuleSectionById(Id: number): Promise<any> {
    return await this.http.get(this.baseService.BaseUrl + 'TrainingCourseModuleSections/' + Id).toPromise();
  }

  public async getTrainingCourseModuleSectionByModule(iModuleId: number): Promise<any> {
    return await this.http.get(this.baseService.BaseUrl + `TrainingCourseModuleSections/${iModuleId}/TrainingCourseModule`).toPromise();
  }

  public async postTrainingCourseModuleSection(trainingCourseModuleSection: TrainingCourseModuleSection): Promise<any> {
    return await this.http.post(this.baseService.BaseUrl + 'TrainingCourseModuleSections', trainingCourseModuleSection).toPromise();
  }

  public async updateTrainingCourseModuleSection(trainingCourseModuleSection: TrainingCourseModuleSection, Id: number): Promise<any> {
    return await this.http.put(this.baseService.BaseUrl + 'TrainingCourseModuleSections/' + Id, trainingCourseModuleSection).toPromise();
  }

  public async deleteTrainingCourseModuleSection(Id: number): Promise<any> {
    return await this.http.delete(this.baseService.BaseUrl + 'TrainingCourseModuleSections/' + Id).toPromise();
  }

}
