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

        public IEnumerable<Statistique> GetAllStatistiques()
        {
            var sondages = satisfactionSurveyEntities.Sondage;

            var sondesAges = from sonde in satisfactionSurveyEntities.Sonde
                             join sondage in sondages on sonde.id equals sondage.idSonde
                             where sonde.id == sondage.idSonde
                             group sonde by sonde.age into s
                             select new { Age = s.Key, Taux = s.Count() * 100 / sondages.Count() };

            var sondesSexes = from sonde in satisfactionSurveyEntities.Sonde
                              join sondage in sondages on sonde.id equals sondage.idSonde
                              where sonde.id == sondage.idSonde
                              group sonde by sonde.sexe into s
                              select new { Sexe = s.Key, Taux = s.Count() * 100 / sondages.Count() };

            var sondesLocalisations = from sonde in satisfactionSurveyEntities.Sonde
                                      join sondage in sondages on sonde.id equals sondage.idSonde
                                      where sonde.id == sondage.idSonde
                                      group sonde by sonde.localisation into s
                                      select new { Localisation = s.Key, Taux = s.Count() * 100 / sondages.Count() };

            List<Statistique> statistiques = new List<Statistique>();

            Statistique nbSondages = new Statistique { Id = 1, Requete = "Nombre de sondages total"};
            Statistique agesSondes = new Statistique { Id = 2, Requete = "L'âge des sondés et leur taux" };
            Statistique sexesSondes = new Statistique { Id = 3, Requete = "Le sexe des sondés et leur taux" };
            Statistique localisationsSondes = new Statistique { Id = 4, Requete = "Le sexe des sondés et leur taux" };

            nbSondages.Reponse = sondages.Count();
            agesSondes.Reponse = sondesAges;
            sexesSondes.Reponse = sondesSexes;
            localisationsSondes.Reponse = sondesLocalisations;

            statistiques.Add(nbSondages);
            statistiques.Add(agesSondes);
            statistiques.Add(sexesSondes);
            statistiques.Add(localisationsSondes);

            return statistiques;
        }

        public IEnumerable<Statistique> GetStatistiqueByFormulaire(int idFormulaire)
        {
            var sondages = satisfactionSurveyEntities.Sondage.Where(f => f.idFormulaire == idFormulaire);

            var tauxChoixReponses = satisfactionSurveyEntities.tauxReponseParQuestion(idFormulaire).ToList();

            var sondesAges = from sonde in satisfactionSurveyEntities.Sonde
                         join sondage in sondages on sonde.id equals sondage.idSonde
                         where sonde.id == sondage.idSonde
                         group sonde by sonde.age into s
                         select new { Age = s.Key, Taux = s.Count()*100/sondages.Count() };

            var sondesSexes = from sonde in satisfactionSurveyEntities.Sonde
                             join sondage in sondages on sonde.id equals sondage.idSonde
                             where sonde.id == sondage.idSonde
                             group sonde by sonde.sexe into s
                             select new { Sexe = s.Key, Taux = s.Count()*100 / sondages.Count() };

            var sondesLocalisations = from sonde in satisfactionSurveyEntities.Sonde
                              join sondage in sondages on sonde.id equals sondage.idSonde
                              where sonde.id == sondage.idSonde
                              group sonde by sonde.localisation into s
                              select new { Localisation = s.Key, Taux = s.Count() * 100 / sondages.Count() };

            List<Statistique> statistiques = new List<Statistique>();

            Statistique tauxReponseParQuestion = new Statistique { Id = 1, Requete = "Taux des réponses pour une question", IdFormulaire = idFormulaire };
            Statistique nbSondagesParFormulaire = new Statistique { Id = 2, Requete = "Nombre de sondages par formulaire", IdFormulaire = idFormulaire };
            Statistique agesSondes = new Statistique { Id = 3, Requete = "L'âge des sondés et leur taux", IdFormulaire = idFormulaire };
            Statistique sexesSondes = new Statistique { Id = 4, Requete = "Le sexe des sondés et leur taux", IdFormulaire = idFormulaire };
            Statistique localisationsSondes = new Statistique { Id = 5, Requete = "La localisation des sondés et leur taux", IdFormulaire = idFormulaire };

            var buffer = tauxChoixReponses[0];
            var reponses = new List<Object>();
            var questions = new List<Object>();
            foreach (var rep in tauxChoixReponses)
            {
                if (rep.idQuestion != buffer.idQuestion)
                {
                    questions.Add( new { Question = buffer.question , Reponses = reponses });
                    reponses = new List<Object> {};
                }
                buffer = rep;
                reponses.Add(new { Reponse = buffer.reponse, Taux = buffer.tauxReponse });
            }
            questions.Add(new { Question = buffer.question, Reponses = reponses });

            tauxReponseParQuestion.Reponse = questions;
            nbSondagesParFormulaire.Reponse = sondages.Count();
            agesSondes.Reponse = sondesAges;
            sexesSondes.Reponse = sondesSexes;
            localisationsSondes.Reponse = sondesLocalisations;

            statistiques.Add(tauxReponseParQuestion);
            statistiques.Add(nbSondagesParFormulaire);
            statistiques.Add(agesSondes);
            statistiques.Add(sexesSondes);
            statistiques.Add(localisationsSondes);

            return statistiques;
        }

        public void Dispose()
        {
            satisfactionSurveyEntities.Dispose();
        }
    }
}