using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AppDevTest.Controllers
{
    public class StageOpdrachtenController : ApiController
    {
        private IStageOpdrachtenRepository sorry { get; set;}
        
        public StageOpdrachtenController(IStageOpdrachtenRepository sor)
        {
            sorry = sor;
        }
        // GET: api/Tag
        public IHttpActionResult Get()
        {
            return Ok(sorry.getByTag());
        }

        // GET: api/Tag/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Tag
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Tag/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Tag/5
        public void Delete(int id)
        {
        }
    }
}
