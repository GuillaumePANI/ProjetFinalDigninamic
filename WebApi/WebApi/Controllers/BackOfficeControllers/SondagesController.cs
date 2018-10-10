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
    public class SondagesController : Controller
    {
        private SondageRepository repo;

        // GET: Sondages
        public ActionResult Index()
        {
            var sondage = repo.GetAllSondage(); ;
            return View(sondage.ToList());
        }

        // GET: Sondages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sondage sondage = repo.GetSondage((int)id);
            if (sondage == null)
            {
                return HttpNotFound();
            }
            return View(sondage);
        }

        // GET: Sondages/Create
        public ActionResult Create()
        {
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
                repo.AddSondage(sondage);
                return RedirectToAction("Index");
            }

            return View(sondage);
        }

        // GET: Sondages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sondage sondage = repo.GetSondage((int)id);
            if (sondage == null)
            {
                return HttpNotFound();
            }
           
            return View(sondage);
        }

        //On est pas sensé modifier les sondages !!!!

        // POST: Sondages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "id,date,idFormulaire,idSonde")] Sondage sondage)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(sondage).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.idFormulaire = new SelectList(db.Formulaire, "id", "titre", sondage.idFormulaire);
        //    ViewBag.idSonde = new SelectList(db.Sonde, "id", "localisation", sondage.idSonde);
        //    return View(sondage);
        //}

        // GET: Sondages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sondage sondage = repo.GetSondage((int)id);
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
            Sondage sondage = repo.GetSondage((int)id);
            repo.DeleteSondage(sondage.id);
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
