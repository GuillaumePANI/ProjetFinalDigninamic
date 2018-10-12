using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.Models;
using WebApi.Repository;

namespace WebApi.Controllers.ApiControllers
{
    public class StatistiqueApiController : ApiController
    {
        public StatistiqueRepository reposStat = new StatistiqueRepository();
 
        // get api/StatistiqueApi/id
        [ResponseType(typeof(List<Statistique>))]
        public IHttpActionResult GetStatistiques(int id)
        {
            var form = reposStat.GetStatistiqueByFormulaire(id);
            return Ok(form);
        }
    }
}
