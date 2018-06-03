import { TrainingCoursesModule } from './training-courses.module';

describe('TrainingCoursesModule', () => {
  let trainingCoursesModule: TrainingCoursesModule;

  beforeEach(() => {
    trainingCoursesModule = new TrainingCoursesModule();
  });

  it('should create an instance', () => {
    expect(trainingCoursesModule).toBeTruthy();
  });
});
