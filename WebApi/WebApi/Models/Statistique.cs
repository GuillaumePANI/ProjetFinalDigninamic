using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class Statistique
    {
        public int Id { get; set; }
        public string Requete { get; set; }
        public string Reponse { get; set; }
        public int IdFormulaire { get; set; }

    }
}