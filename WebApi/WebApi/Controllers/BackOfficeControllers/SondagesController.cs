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
    public class SondagesController : Controller
    {
        private SatisfactionSurveyEntities db = new SatisfactionSurveyEntities();

        // GET: Sondages
        public ActionResult Index()
        {
            var sondage = db.Sondage.Include(s => s.Formulaire).Include(s => s.Sonde);
            return View(sondage.ToList());
        }

        // GET: Sondages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sondage sondage = db.Sondage.Find(id);
            if (sondage == null)
            {
                return HttpNotFound();
            }
            return View(sondage);
        }

        // GET: Sondages/Create
        public ActionResult Create()
        {
            ViewBag.idFormulaire = new SelectList(db.Formulaire, "id", "titre");
            ViewBag.idSonde = new SelectList(db.Sonde, "id", "localisation");
            return View();
        }

        // POST: Sondages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,date,idFormulaire,idSonde")] Sondage sondage)
        {
            if (ModelState.IsValid)
            {
                db.Sondage.Add(sondage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idFormulaire = new SelectList(db.Formulaire, "id", "titre", sondage.idFormulaire);
            ViewBag.idSonde = new SelectList(db.Sonde, "id", "localisation", sondage.idSonde);
            return View(sondage);
        }

        // GET: Sondages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sondage sondage = db.Sondage.Find(id);
            if (sondage == null)
            {
                return HttpNotFound();
            }
            ViewBag.idFormulaire = new SelectList(db.Formulaire, "id", "titre", sondage.idFormulaire);
            ViewBag.idSonde = new SelectList(db.Sonde, "id", "localisation", sondage.idSonde);
            return View(sondage);
        }

        // POST: Sondages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,date,idFormulaire,idSonde")] Sondage sondage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sondage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idFormulaire = new SelectList(db.Formulaire, "id", "titre", sondage.idFormulaire);
            ViewBag.idSonde = new SelectList(db.Sonde, "id", "localisation", sondage.idSonde);
            return View(sondage);
        }

        // GET: Sondages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sondage sondage = db.Sondage.Find(id);
            if (sondage == null)
            {
                return HttpNotFound();
            }
            return View(sondage);
        }

        // POST: Sondages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sondage sondage = db.Sondage.Find(id);
            db.Sondage.Remove(sondage);
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
