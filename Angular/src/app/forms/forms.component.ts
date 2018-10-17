import { Component, OnInit } from '@angular/core';
import { Question } from '../Question';
import { QuestionService } from '../question.service';
import { SondageServiceService } from '../sondage-service.service';

import { FormGroup, FormControl } from "@angular/forms";
import { Sondage } from '../sondage';
import { Router,ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-forms',
  templateUrl: './forms.component.html',
  styleUrls: ['./forms.component.css']
})
export class FormsComponent implements OnInit {
  selected;
  selectedRep;
 quest:Question;
  questions: Array<Question>;
  newRep: Sondage;
  dateModel: any;
  
  constructor(private service: QuestionService,private serviceSondage: SondageServiceService, private router: Router,
    private route: ActivatedRoute) {
    this.service.getAll().subscribe(a => {
      this.questions = a;
      this.questions.sort((q, z) => q.theme.localeCompare(z.theme));
      });
      this.newRep = new Sondage();
   }

   ngOnInit(){
    const id: number = parseInt(this.route.snapshot.params.id, 0);
    
  }

  onSubmit(): void {
    // génération du fake id
    let reps = new Array<Sondage>();
    this.serviceSondage.getAll().subscribe(a => reps = a);
    this.newRep.id = reps.length + 1;
    // ajout de l'article
   // this.newRep.dat = new Date(this.dateModel.year, this.dateModel.month, this.dateModel.day);
    this.serviceSondage.addReponseSondage(this.selectedRep);
    console.log(this.selectedRep);
    this.newRep = new Sondage();

    this.router.navigate(['/Statistics']);
    
}
 



}
