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
    public class ReponsesController : Controller
    {
        private ReponseRepository repo = new ReponseRepository();

        // GET: Reponses
        public ActionResult Index()
        {
            var reponse = repo.GetAllReponses();
            return View(reponse.ToList());
        }

        // GET: Reponses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reponse reponse = repo.GetReponse((int)id);
            if (reponse == null)
            {
                return HttpNotFound();
            }
            return View(reponse);
        }

        //GET: Reponses/Create
        public ActionResult Create()
        {
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
                repo.AddReponse(reponse);
                
                return RedirectToAction("Index");
            }

            return View(reponse);
        }

        // GET: Reponses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reponse reponse = repo.GetReponse((int)id);
            if (reponse == null)
            {
                return HttpNotFound();
            }
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
                repo.EditReponse(reponse);
                return RedirectToAction("Index");
            }
            //ViewBag.idQuestion = new SelectList(db.Question, "id", "contenu", reponse.idQuestion);
            return View(reponse);
        }

        // GET: Reponses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reponse reponse = repo.GetReponse((int)id);
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
            Reponse reponse = repo.GetReponse((int)id);
            repo.DeleteReponse(reponse.id);
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
