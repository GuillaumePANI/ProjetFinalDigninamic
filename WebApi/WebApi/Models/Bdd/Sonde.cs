//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApi.Models.Bdd
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sonde
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sonde()
        {
            this.Sondage = new HashSet<Sondage>();
        }
    
        public int id { get; set; }
        public Nullable<int> age { get; set; }
        public Nullable<bool> sexe { get; set; }
        public string localisation { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sondage> Sondage { get; set; }
    }
}
