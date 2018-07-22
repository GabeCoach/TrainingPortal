import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../../../services/base-service.service';
import { TrainingCourseQuizScores } from '../../models/training-course-quiz-scores';


@Injectable()
export class TrainingCourseQuizScoresService {

  public currentQuizScore: TrainingCourseQuizScores = new TrainingCourseQuizScores;

  constructor(private http: HttpClient, private baseService: BaseService) { }

  public async getTrainingCourseQuizScores(): Promise<any> {
    return await this.http.get(this.baseService.BaseUrl + 'TrainingCourseQuizScores').toPromise();
  }

  public async getScoresByUser(iUserId: number): Promise<any> {
    return await this.http.get(`${this.baseService.BaseUrl}/TrainingCourseQuizScores/${iUserId}/User`).toPromise();
  }

  public async getTrainingCourseQuizScoreById(Id: number): Promise<any> {
    return await this.http.get(this.baseService.BaseUrl + 'TrainingCourseQuizScores/' + Id).toPromise();
  }


  public async postTrainingCourseQuizScore(trainingCourseQuizScore: TrainingCourseQuizScores): Promise<any> {
    return await this.http.post(this.baseService.BaseUrl + 'TrainingCourseQuizScores', trainingCourseQuizScore).toPromise();
  }

  public async updateTrainingCourseQuizScore(trainingCourseQuizScore: TrainingCourseQuizScores, Id: number): Promise<any> {
    return await this.http.put(this.baseService.BaseUrl + 'TrainingCourseQuizScores/' + Id, trainingCourseQuizScore).toPromise();
  }

  public async deleteTrainingCourseQuizScore(Id: number): Promise<any> {
    return await this.http.delete(this.baseService.BaseUrl + 'TrainingCourseQuizScores/' + Id).toPromise();
  }

}
