import { Sonde } from "./sonde";
import { ChoixReponse } from "../choix-reponse";

export interface Newsondage {
    id?:Number;
    Date:Date;
    idFormulaire:Number;
    ChoixReponse:ChoixReponse[];
    Sonde:Sonde;
}
