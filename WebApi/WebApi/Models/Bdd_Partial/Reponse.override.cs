using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApi.Models.Bdd
{
    [MetadataType(typeof(ReponseMetaData))]
    public partial class Reponse
    {
    }

    public class ReponseMetaData
    {
        [Required]
        public string contenu { get; set; }


        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<ChoixReponse> ChoixReponse { get; set; }
    }
}