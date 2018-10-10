﻿using System.Collections.Generic;
using System.Linq;
using WebApi.Models;
using WebApi.Models.Bdd;

namespace WebApi.Repository
{
    public class SondageRepository
    {
        readonly ApplicationDbContext satisfactionSurveyEntities = new ApplicationDbContext();

        public IEnumerable<Sondage> GetAllSondage()
        {
            IEnumerable<Sondage> sondages = satisfactionSurveyEntities.Sondage;
            return sondages;
        }

        public Sondage GetSondage(int id)
        {
            return satisfactionSurveyEntities.Sondage.FirstOrDefault(sondage => sondage.id == id);
        }

        public int AddSondage(Sondage sondage)
        {
            satisfactionSurveyEntities.Sondage.Add(sondage);
            satisfactionSurveyEntities.SaveChanges();
            return sondage.id;
        }

        public void DeleteSondage(int Id)
        {
            satisfactionSurveyEntities.Sondage.Remove(GetSondage(Id));
            satisfactionSurveyEntities.SaveChanges();
        }
    }
}