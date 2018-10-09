using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models.Bdd;

namespace WebApi.Repository
{
    public class ReponseRepository
    {
    readonly SatisfactionSurveyEntities satisfactionSurveyEntities = new SatisfactionSurveyEntities();
    //public ReponseRepository(SatisfactionSurveyEntities satisfactionSurveyEntities)
    //    {
    //        satisfactionSurveyEntities = SatisfactionSurveyEntities;
    //    }

        public IEnumerable<Reponse> GetAllReponses()
        {
            IEnumerable<Reponse> reponses = satisfactionSurveyEntities.Reponse;
            return reponses;
        }

        public Reponse GetReponse(int id)
        {
            return satisfactionSurveyEntities.Reponse.FirstOrDefault(Reponse => Reponse.id == id);
        }

        public int AddFormulaire(Reponse reponse)
        {
            satisfactionSurveyEntities.Reponse.Add(reponse);
            satisfactionSurveyEntities.SaveChanges();
            return reponse.id;
        }

        public int EditReponse(Reponse reponse) //Possibilité de passer seulement les propriétés au lieu d'un objets si nécessaire
        {
            var reponseToEdit = satisfactionSurveyEntities.Reponse.FirstOrDefault(f => f.id == reponse.id);

            if (!string.IsNullOrEmpty(reponse.contenu))
                reponseToEdit.contenu = reponse.contenu;



            satisfactionSurveyEntities.SaveChanges();

            return reponse.id;
        }

        public void DeleteFormulaire(int Id)
        {
            satisfactionSurveyEntities.Reponse.Remove(GetReponse(Id));
            satisfactionSurveyEntities.SaveChanges();
        }




    }
}