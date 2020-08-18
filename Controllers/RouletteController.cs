using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestRoulette.Models;
using TestRoulette.Models.Services;

namespace TestRoulette.Controllers
{
    public class RouletteController : ApiController
    {


        // GET: api/Roulette
        public IEnumerable<Roulette> Get()
        {
            List<Roulette> Roulettes = new List<Roulette>();
            Roulettes=RouletteService.GetRoulettes();

            return Roulettes;

        }

        // GET: api/Roulette/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Roulette
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Roulette/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Roulette/5
        public void Delete(int id)
        {
        }
    }
}
