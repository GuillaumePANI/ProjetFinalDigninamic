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
    public class ReponsesController : Controller
    {
        private SatisfactionSurveyEntities db = new SatisfactionSurveyEntities();

        // GET: Reponses
        public ActionResult Index()
        {
            var reponse = db.Reponse.Include(r => r.Question);
            return View(reponse.ToList());
        }

        // GET: Reponses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reponse reponse = db.Reponse.Find(id);
            if (reponse == null)
            {
                return HttpNotFound();
            }
            return View(reponse);
        }

        // GET: Reponses/Create
        public ActionResult Create()
        {
            ViewBag.idQuestion = new SelectList(db.Question, "id", "contenu");
            return View();
        }

        // POST: Reponses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,contenu,commentaire,idQuestion")] Reponse reponse)
        {
            if (ModelState.IsValid)
            {
                db.Reponse.Add(reponse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idQuestion = new SelectList(db.Question, "id", "contenu", reponse.idQuestion);
            return View(reponse);
        }

        // GET: Reponses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reponse reponse = db.Reponse.Find(id);
            if (reponse == null)
            {
                return HttpNotFound();
            }
            ViewBag.idQuestion = new SelectList(db.Question, "id", "contenu", reponse.idQuestion);
            return View(reponse);
        }

        // POST: Reponses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,contenu,commentaire,idQuestion")] Reponse reponse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reponse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idQuestion = new SelectList(db.Question, "id", "contenu", reponse.idQuestion);
            return View(reponse);
        }

        // GET: Reponses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reponse reponse = db.Reponse.Find(id);
            if (reponse == null)
            {
                return HttpNotFound();
            }
            return View(reponse);
        }

        // POST: Reponses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reponse reponse = db.Reponse.Find(id);
            db.Reponse.Remove(reponse);
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
