﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApi.Models.Bdd_Partial
{
    [MetadataType(typeof(ReponseMetaData))]
    public partial class Reponse
    {
    }

    public class ReponseMetaData
    {
        [Required]
        public string contenu { get; set; }

    }
}