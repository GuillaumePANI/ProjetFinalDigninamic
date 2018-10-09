using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.Models.Bdd;
using WebApi.Repository;

namespace WebApi.Controllers.ApiControllers
{
    public class SondageApiController : ApiController
    {
        public SondageRepository sondagectrl = new SondageRepository();

        //Rappatrier les Sondage
        public IHttpActionResult GetFormulaires()
        {
            return Ok(sondagectrl.GetAllSondage());
        }

        // get api/SondageApi/id
        [ResponseType(typeof(Sondage))]
        public IHttpActionResult GetFormulaires(int id)
        {
            Sondage form = sondagectrl.GetSondage(id);
            return Ok(form);
        }


        // Envoi des réponses dans la table ChoixRéponse
        [HttpPost]
        public IHttpActionResult PostSondage(Sondage sondage)
        {

            return Ok(sondagectrl.AddSondage(sondage));
        }






    }
}