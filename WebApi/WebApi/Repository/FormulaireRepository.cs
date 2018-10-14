using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WebApi.Models;
using WebApi.Models.Bdd;

namespace WebApi.Repository
{
    public class FormulaireRepository
    {
        //public readonly SatisfactionSurveyEntities SatisfactionSurveyEntities;
        //public FormulaireRepository(SatisfactionSurveyEntities satisfactionSurveyEntities)
        //{
        //    satisfactionSurveyEntities = SatisfactionSurveyEntities;
        //}
        readonly SatisfactionSurveyEntities satisfactionSurveyEntities = new SatisfactionSurveyEntities();

        public IEnumerable<Formulaire> GetAllFormulaires()
        {
            IEnumerable<Formulaire> formulaires = satisfactionSurveyEntities.Formulaire;
            return formulaires;
        }

        public Formulaire GetFormulaire(int id)
        {
            return satisfactionSurveyEntities.Formulaire.FirstOrDefault(formulaire => formulaire.id == id);
        }

        public string AddFormulaire(Formulaire formulaire)
        {
            satisfactionSurveyEntities.Formulaire.Add(formulaire);
            satisfactionSurveyEntities.SaveChanges();
            return formulaire.titre;
        }

        public string EditFormulaire(Formulaire formulaire) //Possibilité de passer seulement les propriétés au lieu d'un objets si nécessaire
        {
            var formulaireToEdit = satisfactionSurveyEntities.Formulaire.FirstOrDefault(f => f.id == formulaire.id);

            satisfactionSurveyEntities.Entry(formulaireToEdit).State = EntityState.Modified;

            if (!string.IsNullOrEmpty(formulaire.description))
                formulaireToEdit.description = formulaire.description;

            if (!string.IsNullOrEmpty(formulaire.titre))
                formulaireToEdit.titre = formulaire.titre;
            if (formulaire.dateCloturation != null)
                formulaireToEdit.dateCloturation = formulaire.dateCloturation;

            satisfactionSurveyEntities.SaveChanges();

            return formulaire.titre;
        }

        public void DeleteFormulaire(int Id)
        {
            satisfactionSurveyEntities.Formulaire.Remove(GetFormulaire(Id));
            satisfactionSurveyEntities.SaveChanges();
        }

        public void Dispose()
        {
            satisfactionSurveyEntities.Dispose();
        }

        public int ValidFormulaire(Formulaire form)
        {
            var formulaireToValid = GetFormulaire(form.id);

            formulaireToValid.dateValidation = DateTime.Now;
            satisfactionSurveyEntities.SaveChanges();
            return formulaireToValid.id;
        }
        public int CloseFormulaire(Formulaire form)
        {
            var formulaireToClose = GetFormulaire(form.id);

            formulaireToClose.dateCloturation = DateTime.Now;
            satisfactionSurveyEntities.SaveChanges();
            return formulaireToClose.id;
        }
    }
}