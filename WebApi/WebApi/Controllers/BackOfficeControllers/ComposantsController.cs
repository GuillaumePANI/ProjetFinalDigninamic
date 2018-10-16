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
    [Authorize(Roles = "Admin")]
    public class ComposantsController : Controller
    {
        private ComposantRepository repo = new ComposantRepository();
        private QuestionRepository repoQuestion = new QuestionRepository();

        // GET: Composants
        public ActionResult Index()
        {
            var composant = repo.GetAllComposants();
            return View(composant.ToList());
        }

        // GET: Composants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Composant composant = repo.GetComposant((int)id);
            if (composant == null)
            {
                return HttpNotFound();
            }
            return View(composant);
        }

        // GET: Composants/Create
        public ActionResult Create(int idFormulaire, int questionid)
        {
            //Permet d'afficher la liste de TypeReponse dans la vue
            List<TypeReponse> typeReponses = new TypeReponseRepository().GetAllTypeReponse().ToList();
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var item in typeReponses)
            {
                items.Add(new SelectListItem { Text = item.type, Value = item.id.ToString() });
            }

            //List<Question> questions = new QuestionRepository().GetAllQuestions().ToList();
            //List<SelectListItem> listeQuestion = new List<SelectListItem>();
            //foreach (var item in questions)
            //{
            //    listeQuestion.Add(new SelectListItem { Text = item.contenu, Value = item.id.ToString() });
            //}

            ViewBag.questionid = questionid;
            //ViewBag.listeQuestion = listeQuestion;
            ViewBag.typeReponses = items;
            ViewBag.idFormulaire = idFormulaire;
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
              composant.idQuestion = 
                repo.AddComposant(composant);
                return RedirectToAction("Details", "Formulaires", new { id = composant.idFormulaire });
            }
            return View(composant);
        }

        // GET: Composants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Composant composant = repo.GetComposant((int)id);
            if (composant == null)
            {
                return HttpNotFound();
            }

            List<TypeReponse> typeReponses = new TypeReponseRepository().GetAllTypeReponse().ToList();
            List<SelectListItem> items = new List<SelectListItem>();

            foreach (var item in typeReponses)
            {
                items.Add(new SelectListItem { Text = item.type, Value = item.id.ToString(), Selected = composant.idTypeReponse == item.id });
            }

            ViewBag.typeReponses = items;


            return View(composant);
        }

        // POST: Composants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,idFormulaire,idQuestion,idTypeReponse")] Composant composant)
        {
            if (ModelState.IsValid)
            {
                repo.EditComposant(composant);
                return RedirectToAction("Details", "Composants", new {id = composant.id });
            }
            return View(composant);
        }

        // GET: Composants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Composant composant = repo.GetComposant((int)id);
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
            Composant composant = repo.GetComposant((int)id);
            var idForm = composant.idFormulaire;
            repo.DeleteFormulaire(composant.id);
            return RedirectToAction("Details", "Formulaires", new { id = idForm });
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
