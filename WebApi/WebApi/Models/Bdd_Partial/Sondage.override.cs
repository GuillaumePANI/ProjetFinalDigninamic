using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApi.Models.Bdd_Partial
{
    [MetadataType(typeof(SondageMetaData))]
    public partial class Sondage
    {
    }

    public class SondageMetaData
    {
        [Required]
        public System.DateTime date { get; set;}


    }
}