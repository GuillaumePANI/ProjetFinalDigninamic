using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models.Bdd;

namespace WebApi.Repository
{
    public class TypeReponseRepository
    {
        readonly SatisfactionSurveyEntities satisfactionSurveyEntities = new SatisfactionSurveyEntities();

        public IEnumerable<TypeReponse> GetAllTypeReponse()
        {
            IEnumerable<TypeReponse> typeReponses = satisfactionSurveyEntities.TypeReponse;
            return typeReponses;
        }

        public TypeReponse GettypeReponse(int id)
        {
            return satisfactionSurveyEntities.TypeReponse.FirstOrDefault(composant => composant.id == id);
        }

        public int AddComposant(TypeReponse composant)
        {
            satisfactionSurveyEntities.TypeReponse.Add(composant);
            satisfactionSurveyEntities.SaveChanges();
            return composant.id;
        }

       

        public void DeleteFormulaire(int Id)
        {
            satisfactionSurveyEntities.TypeReponse.Remove(GettypeReponse(Id));
            satisfactionSurveyEntities.SaveChanges();
        }
    }
}
