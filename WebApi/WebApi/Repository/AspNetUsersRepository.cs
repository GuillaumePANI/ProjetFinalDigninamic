using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Controllers;
using WebApi.Models;
using WebApi.Models.Bdd;

namespace WebApi.Repository
{
    public class AspNetUsersRepository
    {
        readonly SatisfactionSurveyEntities satisfactionSurveyEntities = new SatisfactionSurveyEntities();

        public IEnumerable<AspNetUsers> GetAllAspNetUsers()
        {
            IEnumerable<AspNetUsers> users = satisfactionSurveyEntities.AspNetUsers.ToList();
            return users;
        }

        public AspNetUsers GetAspNetUsers(string id)
        {
            return satisfactionSurveyEntities.AspNetUsers.FirstOrDefault(user => user.Id == id);
        }

        public bool SetAspNetUsersRoleAsync(string userId, string roleName)
        {
            var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();

            var user = userManager.FindById(userId);
            var currentRoles = user.Roles.ToList();
            
            foreach (var role in currentRoles)
            {
                var name = new AspNetRolesRepository().GetAspNetRoles(role.RoleId).Name;
                userManager.RemoveFromRole(userId, name);
            }

            var idResult = userManager.AddToRole(userId, roleName);

            return true;
        }

        public void Dispose()
        {
            satisfactionSurveyEntities.Dispose();
        }
    }
}