import { Composant } from "./composant";


export interface SondageInterface {
    Composant:Composant[];
    dateCloturation:string;
    dateValidation:string;
    description:string;
    id:number;
    titre:string;
}
