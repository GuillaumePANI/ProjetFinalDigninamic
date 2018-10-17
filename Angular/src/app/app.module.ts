import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Routes, RouterModule } from '@angular/router';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import {NgbPaginationModule, NgbAlertModule} from '@ng-bootstrap/ng-bootstrap';



import { AppComponent } from './app.component';
import { HttpClientModule } from '../../node_modules/@angular/common/http';
import {QuestionService } from './question.service';
import { FormulaireComponent } from './formulaire/formulaire.component';
import { AuthentificationComponent } from './authentification/authentification.component';
import { FormsComponent } from './forms/forms.component';
import { StatisticsComponent } from './statistics/statistics.component';
import { FormsListComponent } from './forms-list/forms-list.component';
import { AccueilComponent } from './accueil/accueil.component';
import { QuestionReponseComponent } from './question-reponse/question-reponse.component';
import { ApiUserComponent } from './api-user/api-user.component';
import { ApiUserService } from './api-user.service';
import { SondageComponent } from './sondage/sondage.component';
import { StatIdComponent } from './stat-id/stat-id.component';





const appRoutes: Routes = [

  
  {path: 'Statistics', component: StatisticsComponent},
  {path: 'AffForms', component: FormsComponent},
  {path: 'Authentif', component: AuthentificationComponent},
  {path: 'AffFormsList', component: FormsListComponent},
  {path: '', component: AccueilComponent},
  {path: 'Question/:id', component: QuestionReponseComponent },
  //{path: '', component: ApiUserComponent},
  {path: 'Statistics/:id', component: StatIdComponent },
  

 

];
@NgModule({
  declarations: [
    AppComponent,
  
    //ApiUserComponent,
    FormulaireComponent,
    AuthentificationComponent,
    FormsComponent,
    StatisticsComponent,
    FormsListComponent,
    AccueilComponent,
    QuestionReponseComponent,
    ApiUserComponent,
    SondageComponent,
    StatIdComponent
    
  ],
  imports: [
    BrowserModule,
    FormsModule,
    RouterModule.forRoot(appRoutes),
    NgbModule, NgbAlertModule,NgbPaginationModule,
    HttpClientModule
  ],
  providers: [ ApiUserService,QuestionService],
  bootstrap: [AppComponent]
})
export class AppModule { }
