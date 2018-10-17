using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApi.Models.Bdd;
using WebApi.Repository;

namespace WebApi.Controllers.BackOfficeControllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class AspNetUsersController : Controller
    {
        private AspNetUsersRepository repos = new AspNetUsersRepository();

        // GET: AspNetUsers
        public ActionResult Index()
        {
            return View(repos.GetAllAspNetUsers());
        }

        public ActionResult ChangeRole(string id)
        {
            AspNetUsers user = repos.GetAspNetUsers(id);
            List<AspNetRoles> aspNetRoles = new AspNetRolesRepository().GetAllAspNetRoles().ToList();
            List<SelectListItem> items = new List<SelectListItem>();

            foreach (var item in aspNetRoles)
            {
                if (user.AspNetRoles.Count > 0 && string.Equals(user.AspNetRoles.First().Id, item.Id))
                {
                    items.Add(new SelectListItem { Text = item.Name, Value = item.Id, Selected = true });
                } else
                {
                    items.Add(new SelectListItem { Text = item.Name, Value = item.Id });
                }
            }

            ViewBag.roles = items;
            return View(user);
        }

        [HttpPost]
        public ActionResult ChangeRole(AspNetUsers user, string role)
        {
            repos.SetAspNetUsersRoleAsync(user.Id, role);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repos.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
