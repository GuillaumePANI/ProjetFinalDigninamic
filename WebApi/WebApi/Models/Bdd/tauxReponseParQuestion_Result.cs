//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApi.Models.Bdd
{
    using System;
    
    public partial class tauxReponseParQuestion_Result
    {
        public Nullable<int> idQuestion { get; set; }
        public string question { get; set; }
        public int idReponse { get; set; }
        public string reponse { get; set; }
        public Nullable<decimal> tauxReponse { get; set; }
    }
}
