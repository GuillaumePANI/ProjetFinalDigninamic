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
    
    public partial class Formulaire
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Formulaire()
        {
            this.Composant = new HashSet<Composant>();
            this.Sondage = new HashSet<Sondage>();
        }
    
        public int id { get; set; }
        public string titre { get; set; }
        public string description { get; set; }
        public Nullable<System.DateTime> dateCreation { get; set; }
        public Nullable<System.DateTime> dateValidation { get; set; }
        public Nullable<System.DateTime> dateCloturation { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Composant> Composant { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sondage> Sondage { get; set; }
    }
}
