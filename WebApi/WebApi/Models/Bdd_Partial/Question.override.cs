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
    [MetadataType(typeof(QuestionMetaData))]
    public partial class Question
    {
    }

    public class QuestionMetaData
    {
        [Required]
        [Display(Name = "Question")]
        public string contenu { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<Composant> Composant { get; set; }
    }
}