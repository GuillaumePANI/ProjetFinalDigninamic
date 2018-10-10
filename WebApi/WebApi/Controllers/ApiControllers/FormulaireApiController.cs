using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
//using System.Web.Mvc;
using WebApi.Models;
using WebApi.Models.Bdd;
using WebApi.Repository;

namespace WebApi.Controllers.ApiControllers
{
    [Route("api/FormulaireApi")]
    [EnableCors("AllowSpecificOrigin")]
    public class FormulaireApiController : ApiController
    {
        public FormulaireRepository formulairectrl = new FormulaireRepository();

        //Rappatrier les formulaires valides
        [HttpGet]
        public IHttpActionResult GetFormulaires()
        {
            return Ok(formulairectrl.GetAllFormulaires());
        }

        // get api/formulairesapi/id
        [ResponseType(typeof(Formulaire))]
        public IHttpActionResult GetFormulaires(int id)
        {
            Formulaire form = formulairectrl.GetFormulaire(id);
            return Ok(form);
        }


        // Envoi des réponses dans la table ChoixRéponse
        //[HttpPost]
        //public IHttpActionResult(){
        /// Poster les réponses 

       //}


    }
}
