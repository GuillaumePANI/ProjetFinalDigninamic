import { Reponse } from "./Reponse";
import { ChoixReponse } from "./choix-reponse";

export class Sondage {
    
        id : number;
        dat: Date; 
        idFormulaire: number; 
        idSonde : number; 
        Response:Array<Reponse>;
        ChoixResponse:Array<ChoixReponse>;


       
}
