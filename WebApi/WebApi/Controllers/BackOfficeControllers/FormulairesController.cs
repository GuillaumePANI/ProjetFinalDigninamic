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
    public class FormulairesController : Controller
    {
        private FormulaireRepository reposFormulaire = new FormulaireRepository();

        // GET: Formulaires
        public ActionResult Index()
        {
            List<Formulaire> listeformulaire = reposFormulaire.GetAllFormulaires().ToList();
            ViewBag.formulaireToValidate = listeformulaire.Where(a => a.dateValidation == null).ToList();
            ViewBag.formulaireToClose = listeformulaire.Where(a => (a.dateCloturation == null || a.dateCloturation > DateTime.Now )&& a.dateValidation != null).ToList();
            ViewBag.formulaireClosed = listeformulaire.Where(a => a.dateCloturation < DateTime.Now).ToList();

            return View();
        }

        // GET: Formulaires/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Formulaire formulaire = reposFormulaire.GetFormulaire((int)id);
            if (formulaire == null)
            {
                return HttpNotFound();
            } 
            return View(formulaire);
            
        }

        // GET: Formulaires/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Formulaires/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,titre,description,dateCreation,dateValidation,dateCloturation")] Formulaire formulaire)
        {
            if (ModelState.IsValid)
            {
                formulaire.dateCreation = DateTime.Now;
                reposFormulaire.AddFormulaire(formulaire);
                return RedirectToAction("Index");
            }

            return View(formulaire);
        }

        // GET: Formulaires/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Formulaire formulaire = reposFormulaire.GetFormulaire((int)id);
            if (formulaire == null)
            {
                return HttpNotFound();
            }
            return View(formulaire);
        }

        // POST: Formulaires/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,titre,description,dateCreation,dateValidation,dateCloturation")] Formulaire formulaire)
        {
            if (ModelState.IsValid)
            {
                reposFormulaire.EditFormulaire(formulaire);
                return RedirectToAction("Index");
            }
            return View(formulaire);
        }

        // GET: Formulaires/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Formulaire formulaire = reposFormulaire.GetFormulaire((int)id);
            if (formulaire == null)
            {
                return HttpNotFound();
            }
            return View(formulaire);
        }

        // POST: Formulaires/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            reposFormulaire.DeleteFormulaire(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                reposFormulaire.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
