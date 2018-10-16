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
            List<Statistique> statistiques = new List<Statistique>();

            var formulaires = from form in satisfactionSurveyEntities.Formulaire
                              where form.dateCloturation.HasValue && form.dateCloturation.Value <= DateTime.Now
                              select form;

            foreach (var formulaire in formulaires)
            {
                Statistique statistique = GetStatistiqueByFormulaire(formulaire.id);
                statistique.TitreFormulaire = formulaire.titre;
                statistiques.Add(statistique);
            }

            return statistiques;
        }

        public Statistique GetStatistiqueByFormulaire(int idFormulaire)
        {
            var sondages = satisfactionSurveyEntities.Sondage.Where(f => f.idFormulaire == idFormulaire);

            var tauxChoixReponses = satisfactionSurveyEntities.tauxReponseParQuestion(idFormulaire).ToList();

            var sondesAges = from sonde in satisfactionSurveyEntities.Sonde
                             join sondage in sondages on sonde.id equals sondage.idSonde
                             where sonde.id == sondage.idSonde
                             group sonde by sonde.age into s
                             select new RequeteAge { Age = s.Key, Taux = s.Count() * 100 / sondages.Count() };

            var sondesSexes = from sonde in satisfactionSurveyEntities.Sonde
                              join sondage in sondages on sonde.id equals sondage.idSonde
                              where sonde.id == sondage.idSonde
                              group sonde by sonde.sexe into s
                              select new RequeteSexe { Sexe = s.Key, Taux = s.Count() * 100 / sondages.Count() };

            var sondesLocalisations = from sonde in satisfactionSurveyEntities.Sonde
                                      join sondage in sondages on sonde.id equals sondage.idSonde
                                      where sonde.id == sondage.idSonde
                                      group sonde by sonde.localisation into s
                                      select new RequeteLocalisation { Localisation = s.Key, Taux = s.Count() * 100 / sondages.Count() };

            var buffer = tauxChoixReponses[0];
            var reponses = new List<StatReponse>();
            var questions = new List<StatQuestion>();
            foreach (var rep in tauxChoixReponses)
            {
                if (rep.idQuestion != buffer.idQuestion)
                {
                    questions.Add(new StatQuestion { Contenu = buffer.question, Reponses = reponses });
                    reponses = new List<StatReponse> { };
                }
                buffer = rep;
                reponses.Add(new StatReponse { Contenu = buffer.reponse, Taux = buffer.tauxReponse });
            }
            questions.Add(new StatQuestion { Contenu = buffer.question, Reponses = reponses });


            Statistique statistique = new Statistique {
                TauxChoixReponse = questions,
                NbSondes = sondages.Count(),
                TauxAge  = sondesAges.ToList(),
                TauxSexe = sondesSexes.ToList(),
                TauxLocalisation = sondesLocalisations.ToList()
            };

            return statistique;
        }

        public void Dispose()
        {
            satisfactionSurveyEntities.Dispose();
        }
    }
}