import { QuizSheet } from './quiz-sheet';
import { QuizUserSelectedAnswers } from './quiz-user-selected-answers';

export class QuizGrader {
    public quiz_sheet: QuizSheet;
    public selected_answers: QuizUserSelectedAnswers[];
}
