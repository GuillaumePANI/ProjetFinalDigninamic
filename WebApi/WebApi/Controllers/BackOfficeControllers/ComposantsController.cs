using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApi.Models.Bdd;

namespace WebApi.Controllers.BackOfficeControllers
{
    public class ComposantsController : Controller
    {
        private SatisfactionSurveyEntities db = new SatisfactionSurveyEntities();

        // GET: Composants
        public ActionResult Index()
        {
            var composant = db.Composant.Include(c => c.Formulaire).Include(c => c.Question).Include(c => c.TypeReponse);
            return View(composant.ToList());
        }

        // GET: Composants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Composant composant = db.Composant.Find(id);
            if (composant == null)
            {
                return HttpNotFound();
            }
            return View(composant);
        }

        // GET: Composants/Create
        public ActionResult Create()
        {
            ViewBag.idFormulaire = new SelectList(db.Formulaire, "id", "titre");
            ViewBag.idQuestion = new SelectList(db.Question, "id", "contenu");
            ViewBag.idTypeReponse = new SelectList(db.TypeReponse, "id", "type");
            return View();
        }

        // POST: Composants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idFormulaire,idQuestion,idTypeReponse")] Composant composant)
        {
            if (ModelState.IsValid)
            {
                db.Composant.Add(composant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idFormulaire = new SelectList(db.Formulaire, "id", "titre", composant.idFormulaire);
            ViewBag.idQuestion = new SelectList(db.Question, "id", "contenu", composant.idQuestion);
            ViewBag.idTypeReponse = new SelectList(db.TypeReponse, "id", "type", composant.idTypeReponse);
            return View(composant);
        }

        // GET: Composants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Composant composant = db.Composant.Find(id);
            if (composant == null)
            {
                return HttpNotFound();
            }
            ViewBag.idFormulaire = new SelectList(db.Formulaire, "id", "titre", composant.idFormulaire);
            ViewBag.idQuestion = new SelectList(db.Question, "id", "contenu", composant.idQuestion);
            ViewBag.idTypeReponse = new SelectList(db.TypeReponse, "id", "type", composant.idTypeReponse);
            return View(composant);
        }

        // POST: Composants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idFormulaire,idQuestion,idTypeReponse")] Composant composant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(composant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idFormulaire = new SelectList(db.Formulaire, "id", "titre", composant.idFormulaire);
            ViewBag.idQuestion = new SelectList(db.Question, "id", "contenu", composant.idQuestion);
            ViewBag.idTypeReponse = new SelectList(db.TypeReponse, "id", "type", composant.idTypeReponse);
            return View(composant);
        }

        // GET: Composants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Composant composant = db.Composant.Find(id);
            if (composant == null)
            {
                return HttpNotFound();
            }
            return View(composant);
        }

        // POST: Composants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Composant composant = db.Composant.Find(id);
            db.Composant.Remove(composant);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
