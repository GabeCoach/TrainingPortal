import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../../../services/base-service.service';
import { TrainingCourseModuleSubSection } from '../../models/training-course-module-sub-section';

@Injectable()
export class TrainingCourseModuleSubSectionService {

  constructor(private http: HttpClient, private baseService: BaseService) { }

  public getTrainingCourseModuleSubSections(): Promise<any> {
    return this.http.get(this.baseService.BaseUrl + 'TrainingCourseModuleSubSections').toPromise();
  }

  public getTrainingCourseModuleSubSectionById(Id: number): Promise<any> {
    return this.http.get(this.baseService.BaseUrl + 'TrainingCourseModuleSubSections/' + Id).toPromise();
  }


  public postTrainingCourseModuleSubSection(trainingCourseModuleSubSection: TrainingCourseModuleSubSection): Promise<any> {
    return this.http.post(this.baseService.BaseUrl + 'TrainingCourseModuleSubSections', trainingCourseModuleSubSection).toPromise();
  }

  public updateTrainingCourseModuleSubSection(trainingCourseModuleSubSection: TrainingCourseModuleSubSection, Id: number): Promise<any> {
    return this.http.put(this.baseService.BaseUrl + 'TrainingCourseModuleSubSections/' + Id, trainingCourseModuleSubSection).toPromise();
  }

  public deleteTrainingCourseModuleSubSection(Id: number): Promise<any> {
    return this.http.delete(this.baseService.BaseUrl + 'TrainingCourseModuleSubSections/' + Id).toPromise();
  }

}
