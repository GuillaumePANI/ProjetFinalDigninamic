using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class Statistique
    {
        public int IdFormulaire { get; set; }
        public string TitreFormulaire { get; set; }
        public List<StatQuestion> TauxChoixReponse { get; set; }
        public int NbSondes { get; set; }
        public List<RequeteAge> TauxAge { get; set; }
        public List<RequeteSexe> TauxSexe { get; set; }
        public List<RequeteLocalisation> TauxLocalisation { get; set; }
    }

    public class StatQuestion
    {
        public string Contenu { get; set; }
        public List<StatReponse> Reponses { get; set; }
    }

    public class StatReponse
    {
        public string Contenu { get; set; }
        public decimal? Taux { get; set; }
    }

    public class RequeteAge
    {
        public int? Age { get; set; }
        public double Taux { get; set; }
    }

    public class RequeteSexe
    {
        public bool? Sexe { get; set; }
        public double Taux { get; set; }
    }

    public class RequeteLocalisation
    {
        public string Localisation { get; set; }
        public double Taux { get; set; }
    }

    public class IdTitreDateFormulaire
    {
        public int IdFormulaire { get; set; }
        public string TitreFormulaire { get; set; }
        public DateTime? DateCloture { get; set; }
    }
}