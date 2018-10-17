import { Component, OnInit, Input } from '@angular/core';
import { Sondage } from '../sondage';

@Component({
  selector: 'app-sondage',
  templateUrl: './sondage.component.html',
  styleUrls: ['./sondage.component.css']
})
export class SondageComponent implements OnInit {
  @Input() Respons: Sondage;

  constructor() { }

  ngOnInit() {
  }

}
