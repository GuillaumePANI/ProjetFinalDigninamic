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
    using System.Collections.Generic;
    
    public partial class Sondage
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sondage()
        {
            this.ChoixReponse = new HashSet<ChoixReponse>();
        }
    
        public int id { get; set; }
        public System.DateTime date { get; set; }
        public Nullable<int> idFormulaire { get; set; }
        public Nullable<int> idSonde { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChoixReponse> ChoixReponse { get; set; }
        public virtual Formulaire Formulaire { get; set; }
        public virtual Sonde Sonde { get; set; }
    }
}