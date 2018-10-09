using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using WebApi.Models.Bdd;

namespace WebApi.Models.Bdd_Partial
{
    [MetadataType(typeof(QuestionMetaData))]
    public partial class Question
    {
    }

    public class QuestionMetaData
    {
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<Composant> Composant { get; set; }
    }
}