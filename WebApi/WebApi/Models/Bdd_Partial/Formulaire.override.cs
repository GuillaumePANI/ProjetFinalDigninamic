using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using WebApi.Models.Bdd;

namespace WebApi.Models.Bdd
{
    [MetadataType(typeof(FormulaireMetaData))]
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
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime dateCreation { get; set; }

        [Required]
        [Display(Name = "Date de validation")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime dateValidation { get; set; }

        [Required]
        [Display(Name = "Date de clôture")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime dateCloturation { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<Sondage> Sondage { get; set; }
      
        public virtual ICollection<Composant> Composant { get; set; }

    }
}