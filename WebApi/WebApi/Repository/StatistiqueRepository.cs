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

            var formulaires = (from form in satisfactionSurveyEntities.Formulaire
                               where form.dateCloturation.HasValue && form.dateCloturation.Value <= DateTime.Now
                               select form).ToList();

            foreach (var formulaire in formulaires)
            {
                if (formulaire.id > 0)
                {
                    Statistique statistique = GetStatistiqueByFormulaire(formulaire.id);
                    statistiques.Add(statistique);
                }
            }

            return statistiques;
        }

        public Statistique GetStatistiqueByFormulaire(int idFormulaire)
        {
            var sondages = satisfactionSurveyEntities.Sondage.Where(f => f.idFormulaire == idFormulaire);

            var questions = new List<StatQuestion>();

            using (var tauxChoixReponses = satisfactionSurveyEntities.tauxReponseParQuestion(idFormulaire))
            {
                var listChoix = tauxChoixReponses.ToList();
                if (listChoix.Count > 0)
                {
                    var buffer = listChoix[0];
                    var reponses = new List<StatReponse>();

                    foreach (var rep in listChoix)
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
                }
            }

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

            Statistique statistique = new Statistique
            {
                TitreFormulaire = satisfactionSurveyEntities.Formulaire.Find(idFormulaire).titre,
                TauxChoixReponse = questions,
                NbSondes = sondages.Count(),
                TauxAge = sondesAges.ToList(),
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