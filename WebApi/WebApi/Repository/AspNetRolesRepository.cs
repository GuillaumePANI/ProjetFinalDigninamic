using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models.Bdd;

namespace WebApi.Repository
{
    public class AspNetRolesRepository
    {
        readonly SatisfactionSurveyEntities satisfactionSurveyEntities = new SatisfactionSurveyEntities();

        public IEnumerable<AspNetRoles> GetAllAspNetRoles()
        {
            IEnumerable<AspNetRoles> roles = satisfactionSurveyEntities.AspNetRoles.ToList();
            return roles;
        }

        public AspNetRoles GetAspNetRoles(string id)
        {
            return satisfactionSurveyEntities.AspNetRoles.FirstOrDefault(user => user.Id == id);
        }
    }
}