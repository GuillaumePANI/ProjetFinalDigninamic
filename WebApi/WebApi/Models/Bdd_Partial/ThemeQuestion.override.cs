using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApi.Models.Bdd
{
    [MetadataType(typeof(ThemeQuestionMetaData))]
    public partial class ThemeQuestion
    {
    }

    public class ThemeQuestionMetaData
    {
        [Required]
        [Display(Name = "Theme")]
        public string theme { get; set; }
    }
}