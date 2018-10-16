using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApi.Models;
using WebApi.Models.Bdd;
using WebApi.Repository;

namespace WebApi.Controllers.BackOfficeControllers
{
    [Authorize(Roles = "Admin")]
    public class StatistiquesController : Controller
    {
        private readonly FormulaireRepository formRepo = new FormulaireRepository();
        private readonly StatistiqueRepository statRepo = new StatistiqueRepository();

        // GET: Satisistiques
        public ActionResult Index()
        {
            List<Formulaire> formulairesClos = formRepo.GetAllFormulaires().Where(f => f.dateCloturation < DateTime.Now).ToList();

            return View(formulairesClos);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Statistique statsFormulaire = statRepo.GetStatistiqueByFormulaire((int)id);
            if (statsFormulaire == null)
            {
                return HttpNotFound();
            }
            return View(statsFormulaire);

        }
    }
}
