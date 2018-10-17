import { Injectable } from '@angular/core';
import {HttpClient,HttpHeaders} from '@angular/common/http'
import { Observable } from 'rxjs';

import { SondageInterface } from './entities/sondage';

import { Newsondage } from './entities/newsondage';


@Injectable({
  providedIn: 'root'
})

export class ApiUserService {
  url='http://satisfactionsurveyapi.azurewebsites.net/api/FormulaireApi';
  
  stats: Array<object>;
  constructor(private http: HttpClient) { 
   
  }
  getAllUser(): Observable<Object>{ 

    
      return this.http.get<Object>('http://satisfactionsurveyapi.azurewebsites.net/api/FormulaireApi/');

  }
  getAllQ(id : number): Observable<SondageInterface>
  { 
     //let headers: HttpHeaders = new HttpHeaders();
  const httpOptions={
   
    headers:new HttpHeaders({'Content-Type': 'application/json'})
     };

     console.log(id);
    return this.http.get<SondageInterface>(`http://satisfactionsurveyapi.azurewebsites.net/api/FormulaireApi/${id}`);
   // .pipe( tap(_ => this.log(`fetched question id=${id}`)), catchError(this.handleError<Object>(`getQuestion id=${id}`)));
   
    }

   

 
  addSondage(data:Newsondage) :Observable<any> {
    let headers: HttpHeaders = new HttpHeaders();
    headers.set('Content-Type', 'application/json');
    console.log("data:"+JSON.stringify(data));
    return this.http.post('http://satisfactionsurveyapi.azurewebsites.net/api/SondageApi',JSON.stringify(data), { headers: headers })
    
    
  }
  getAllStat(): Observable<Object>
  { 
    
  const httpOptions={

    headers:new HttpHeaders({'Content-Type': 'application/json'})
     };

     //console.log(id);
    return this.http.get<Object>(`http://satisfactionsurveyapi.azurewebsites.net/api/StatistiqueApi/`);
   
   
    }
    getOneStat(id): Observable<Object> {

      const httpOptions = {
  
        headers: new HttpHeaders({ 'Content-Type': 'application/json' })
      };
  
      //console.log(id);
      return this.http.get<Object>(`http://satisfactionsurveyapi.azurewebsites.net/api/StatistiqueApi/${id}`);
  
  
    }
    
}



