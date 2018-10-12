using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WebApi.Models;
using WebApi.Models.Bdd;

namespace WebApi.Repository
{
    public class StatistiqueRepository
    {
        readonly SatisfactionSurveyEntities satisfactionSurveyEntities = new SatisfactionSurveyEntities();

        public IEnumerable<Statistique> GetStatistiqueByFormulaire(int idFormulaire)
        {
            var sondages = satisfactionSurveyEntities.Sondage.Where(f => f.idFormulaire == idFormulaire);
            var sondes = from sonde in satisfactionSurveyEntities.Sonde
                         join sondage in sondages on sonde.id equals sondage.idSonde
                         where sonde.id == sondage.idSonde
                         group sonde by sonde.age into s
                         select new { Age = s.Key, Nombre = s.Count() };

            List<Statistique> statistiques = new List<Statistique>();

            Statistique nbSondagesParFormulaire = new Statistique { Id = 1, Requete = "nombre de sondages par formulaire", IdFormulaire = idFormulaire };
            Statistique tauxReponseParQuestion = new Statistique { Id = 2, Requete = "taux des réponses pour une question", IdFormulaire = idFormulaire };
            Statistique agesSondes = new Statistique { Id = 3, Requete = "L'âge des sondés et leur taux", IdFormulaire = idFormulaire };

            nbSondagesParFormulaire.Reponse = string.Format("{0}", sondages.Count());
            tauxReponseParQuestion.Reponse = string.Format("{0}", "");
            agesSondes.Reponse = string.Join(", ", sondes); 

            statistiques.Add(nbSondagesParFormulaire);
            statistiques.Add(tauxReponseParQuestion);
            statistiques.Add(agesSondes);

            return statistiques;
        }

        public void Dispose()
        {
            satisfactionSurveyEntities.Dispose();
        }
    }
}