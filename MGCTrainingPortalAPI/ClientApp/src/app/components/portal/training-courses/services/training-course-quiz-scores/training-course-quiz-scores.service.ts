import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../../../services/base-service.service';
import { TrainingCourseQuizScores } from '../../models/training-course-quiz-scores';


@Injectable()
export class TrainingCourseQuizScoresService {

  public currentQuizScore: TrainingCourseQuizScores = new TrainingCourseQuizScores;

  constructor(private http: HttpClient, private baseService: BaseService) { }

  public getTrainingCourseQuizScores(): Promise<any> {
    return this.http.get(this.baseService.BaseUrl + 'TrainingCourseQuizScores').toPromise();
  }

  public getTrainingCourseQuizScoreById(Id: number): Promise<any> {
    return this.http.get(this.baseService.BaseUrl + 'TrainingCourseQuizScores/' + Id).toPromise();
  }


  public postTrainingCourseQuizScore(trainingCourseQuizScore: TrainingCourseQuizScores): Promise<any> {
    return this.http.post(this.baseService.BaseUrl + 'TrainingCourseQuizScores', trainingCourseQuizScore).toPromise();
  }

  public updateTrainingCourseQuizScore(trainingCourseQuizScore: TrainingCourseQuizScores, Id: number): Promise<any> {
    return this.http.put(this.baseService.BaseUrl + 'TrainingCourseQuizScores/' + Id, trainingCourseQuizScore).toPromise();
  }

  public deleteTrainingCourseQuizScore(Id: number): Promise<any> {
    return this.http.delete(this.baseService.BaseUrl + 'TrainingCourseQuizScores/' + Id).toPromise();
  }

}
