using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using WebApi.Models;
using WebApi.Repository;

namespace WebApi.Controllers.ApiControllers
{
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    public class StatistiqueApiController : ApiController
    {
        public StatistiqueRepository reposStat = new StatistiqueRepository();

        public IHttpActionResult GetStatistiques()
        {
            return Ok(reposStat.GetAllStatistiques());
        }

        // get api/StatistiqueApi/id
        [ResponseType(typeof(List<Statistique>))]
        public IHttpActionResult GetStatistiques(int id)
        {
            var form = reposStat.GetStatistiqueByFormulaire(id);
            return Ok(form);
        }
    }
}
