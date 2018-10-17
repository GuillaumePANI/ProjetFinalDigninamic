import { Injectable } from '@angular/core';
import { Sondage } from './sondage';
import { SONDAGES } from './mock-sondage';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SondageServiceService {
  responses: Array<Sondage>;
  constructor() {
    //this.responses = SONDAGES;
   }

  addReponseSondage(rep: Sondage): void {
    this.responses.push(rep);
  }
  getAll(): Observable<Array<Sondage>> {
    return of(this.responses);
  }
}
