using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApi.Models.Bdd
{
    [MetadataType(typeof(TypeReponseMetaData))]
    public partial class TypeReponse
    {
    }

    public class TypeReponseMetaData
    {
        [Required]
        public string type { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<Composant> Composant { get; set; }
    }
}