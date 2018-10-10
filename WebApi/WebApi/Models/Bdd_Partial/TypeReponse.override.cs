using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApi.Models.Bdd_Partial
{
    [MetadataType(typeof(TypeReponseMetaData))]
    public partial class TypeReponse
    {
    }

    public class TypeReponseMetaData
    {
        [Required]
        public string type { get; set; }
    }
}