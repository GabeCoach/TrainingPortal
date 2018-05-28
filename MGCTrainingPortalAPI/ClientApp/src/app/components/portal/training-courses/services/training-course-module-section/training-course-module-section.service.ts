import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../../../services/base-service.service';
import { TrainingCourseModuleSection } from '../../models/training-course-module-section';


@Injectable()
export class TrainingCourseModuleSectionService {

  trainingCourseModuleId: number;

  constructor(private http: HttpClient, private baseService: BaseService) { }

  public getTrainingCourseModuleSections(): Promise<any> {
    return this.http.get(this.baseService.BaseUrl + 'TrainingCourseModuleSections').toPromise();
  }

  public getTrainingCourseModuleSectionById(Id: number): Promise<any> {
    return this.http.get(this.baseService.BaseUrl + 'TrainingCourseModuleSections/' + Id).toPromise();
  }

  public getTrainingCourseModuleSectionByModule(iModuleId: number): Promise<any> {
    return this.http.get(this.baseService.BaseUrl + `TrainingCourseModuleSections/${iModuleId}/TrainingCOurseModule`).toPromise();
  }

  public postTrainingCourseModuleSection(trainingCourseModuleSection: TrainingCourseModuleSection): Promise<any> {
    return this.http.post(this.baseService.BaseUrl + 'TrainingCourseModuleSections', trainingCourseModuleSection).toPromise();
  }

  public updateTrainingCourseModuleSection(trainingCourseModuleSection: TrainingCourseModuleSection, Id: number): Promise<any> {
    return this.http.put(this.baseService.BaseUrl + 'TrainingCourseModuleSections/' + Id, trainingCourseModuleSection).toPromise();
  }

  public deleteTrainingCourseModuleSection(Id: number): Promise<any> {
    return this.http.delete(this.baseService.BaseUrl + 'TrainingCourseModuleSections/' + Id).toPromise();
  }

}
