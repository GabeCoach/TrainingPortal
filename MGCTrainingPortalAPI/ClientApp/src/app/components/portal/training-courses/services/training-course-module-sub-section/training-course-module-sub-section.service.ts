import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../../../services/base-service.service';
import { TrainingCourseModuleSubSection } from '../../models/training-course-module-sub-section';

@Injectable()
export class TrainingCourseModuleSubSectionService {

  public iSectionId: number;

  constructor(private http: HttpClient, private baseService: BaseService) { }

  public async getTrainingCourseModuleSubSections(): Promise<any> {
    return await this.http.get(this.baseService.BaseUrl + 'TrainingCourseModuleSubSections').toPromise();
  }

  public async getTrainingCourseModuleSubSectionById(Id: number): Promise<any> {
    return await this.http.get(this.baseService.BaseUrl + 'TrainingCourseModuleSubSections/' + Id).toPromise();
  }

  public async getModuleSubSectionByModuleSection(iModuleSectionId: number): Promise<any> {
    // tslint:disable-next-line:max-line-length
    return await this.http.get(this.baseService.BaseUrl + `TrainingCourseModuleSubSections/${iModuleSectionId}/TrainingCourseModuleSection`).toPromise();
  }

  public async postTrainingCourseModuleSubSection(trainingCourseModuleSubSection: TrainingCourseModuleSubSection): Promise<any> {
    return await this.http.post(this.baseService.BaseUrl + 'TrainingCourseModuleSubSections', trainingCourseModuleSubSection).toPromise();
  }

  public async updateTrainingCourseModuleSubSection(trainingCourseModuleSubSection: TrainingCourseModuleSubSection, Id: number): Promise<any> {
    return await this.http.put(this.baseService.BaseUrl + 'TrainingCourseModuleSubSections/' + Id, trainingCourseModuleSubSection).toPromise();
  }

  public async deleteTrainingCourseModuleSubSection(Id: number): Promise<any> {
    return await this.http.delete(this.baseService.BaseUrl + 'TrainingCourseModuleSubSections/' + Id).toPromise();
  }

}
