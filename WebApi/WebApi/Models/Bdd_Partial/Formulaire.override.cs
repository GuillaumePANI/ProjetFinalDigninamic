using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApi.Models.Bdd;

namespace WebApi.Models.Bdd_Partial
{
    [MetadataType(typeof(QuestionMetaData))]
    public partial class Formulaire
    {
    }

    public class FormulaireMetaData
    {
        [Required]
        [Display(Name = "Titre")]
        public string titre { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string description { get; set; }

        [Required]
        [Display(Name = "Date de création")]
        public Nullable<System.DateTime> dateCreation { get; set; }

        [Required]
        [Display(Name = "Date de validation")]
        public Nullable<System.DateTime> dateValidation { get; set; }

        [Required]
        [Display(Name = "date de clôture")]
        public Nullable<System.DateTime> dateCloturation { get; set; }

      
        public virtual ICollection<Sondage> Sondage { get; set; }
      
        public virtual ICollection<Composant> Composant { get; set; }

    }
}