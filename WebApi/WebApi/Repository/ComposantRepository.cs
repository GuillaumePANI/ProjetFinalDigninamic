using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApi.Models.Bdd;

namespace WebApi.Repository
{
    public class ComposantRepository
    {
        readonly SatisfactionSurveyEntities satisfactionSurveyEntities = new SatisfactionSurveyEntities();

        public IEnumerable<Composant> GetAllComposants()
        {
            IEnumerable<Composant> composants = satisfactionSurveyEntities.Composant;
            return composants;
        }

        public Composant GetComposant(int id)
        {
            return satisfactionSurveyEntities.Composant.FirstOrDefault(composant => composant.id == id);
        }

        public int AddComposant(Composant composant)
        {
            satisfactionSurveyEntities.Composant.Add(composant);
            satisfactionSurveyEntities.SaveChanges();
            return composant.id;
        }

        public int EditComposant(Composant composant) //Possibilité de passer seulement les propriétés au lieu d'un objets si nécessaire
        {
         //   var composantToEdit = satisfactionSurveyEntities.Composant.FirstOrDefault(f => f.id == composant.id);
            var composantToEdit = satisfactionSurveyEntities.Composant.Find(composant.id);

            //satisfactionSurveyEntities.Entry(composantToEdit).State = EntityState.Modified;



            composantToEdit.Question = composant.Question;
            composantToEdit.idTypeReponse = composant.idTypeReponse;

            satisfactionSurveyEntities.SaveChanges();

            return composant.id;
        }

        public void DeleteFormulaire(int Id)
        {
            satisfactionSurveyEntities.Composant.Remove(GetComposant(Id));
            satisfactionSurveyEntities.SaveChanges();
        }
    }
}