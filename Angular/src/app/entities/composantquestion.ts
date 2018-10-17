import { ReponseInterface } from "./reponse";

export interface ComposantQuestion {
    Reponse:ReponseInterface[];
    ThemQuestion:any;
    contenu:string;
    id:Number;
    idTheme:any;
}
