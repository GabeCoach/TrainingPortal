export class TrainingCourseQuizScores {
    public Id: number;
    public training_course_quiz_id: number;
    public user_id: number;
    public quiz_percentage: number;
    public quiz_correct_answers: number;
    public quiz_incorrect_answers: number;
    public quiz_total_answers: number;
    public quiz_total_answers_possible: number;
    public date_added: string;
    public date_updated: string;
}