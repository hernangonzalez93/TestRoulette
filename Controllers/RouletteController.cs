using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
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
        public int Post([FromBody]string value)
        {
            return RouletteService.CreateRoulette();
        }

        [HttpPut]
        [Route("api/OpenRoulette")]
        public HttpResponseMessage OpenRoulette(Roulette roulette)
        {

            var response = Request.CreateResponse(HttpStatusCode.NotImplemented);

            var res = RouletteService.OpenRoulette(roulette.Id);

            if(res>=1)
            {
                response = Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.NotModified);
            }


            return response;
        }

        [HttpPost]
        [Route("api/CreateBet")]
        public HttpResponseMessage CreateBet(HttpRequestMessage request, [FromBody] Bets bet)
        {
            var response = Request.CreateResponse(HttpStatusCode.NotImplemented);
            var headers = request.Headers;
            var iduser = headers.GetValues("User");
            bet.User_Id = Convert.ToInt32(iduser.FirstOrDefault());
            var res = RouletteService.CreateBet(bet);

            if(res>=1)
            {
                response = Request.CreateResponse(HttpStatusCode.Created);
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest);
            }


            return response;

        }
    }
}
