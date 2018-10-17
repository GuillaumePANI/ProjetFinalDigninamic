import { Component, OnInit } from '@angular/core';
import { Question } from '../Question';
import { Reponse } from '../Reponse';
import { QuestionService } from '../question.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-question-reponse',
  templateUrl: './question-reponse.component.html',
  styleUrls: ['./question-reponse.component.css']
})
export class QuestionReponseComponent implements OnInit {

  question: Question;
  newRep: Reponse;
  constructor(private service: QuestionService, private route: ActivatedRoute) {
    const id: number = parseInt(this.route.snapshot.params.id, 0);
    this.question = this.service.find(id);
   }

  ngOnInit() {
    this.newRep = new Reponse();
  }

}


