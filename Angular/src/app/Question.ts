import { Reponse } from "./Reponse";
export class Question {
    id: number;
    theme: string;
    content: string;
    Responses:Array<Reponse>;
    
    

    constructor() {
        
        this.id = 0;
        this.theme = '';
        this.content = '';
        this.Responses=new Array<Reponse>();
    }
}