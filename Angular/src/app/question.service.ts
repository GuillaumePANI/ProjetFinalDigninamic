import { Injectable, Input } from '@angular/core';
import { Question } from './Question';
import { Sondage } from './sondage';

import { QUESTIONS } from './mock-question';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class QuestionService {
  
 
 
  questions: Array<Question>;
  constructor() {
    this.questions = QUESTIONS;
   }

   getAll(): Observable<Array<Question>> {
     return of(this.questions);
   }

   

   find(id: number): Question {
      for (const a of this.questions) {
        if (id === a.id) {
          return a;
        }
      }
   }

   update(question: Question): void {
    this.questions = this.questions.filter(a => a.id !== question.id);
    this.questions.push(question);
 }
}
