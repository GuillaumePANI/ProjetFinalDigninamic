import { Component, OnInit, Input } from '@angular/core';
import { Question } from '../Question';

@Component({
  selector: 'app-formulaire',
  templateUrl: './formulaire.component.html',
  styleUrls: ['./formulaire.component.css']
})
export class FormulaireComponent implements OnInit {

  @Input() question: Question;


  constructor() { }

  ngOnInit() {
  }

}
