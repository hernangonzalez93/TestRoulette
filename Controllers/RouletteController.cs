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


        [HttpGet]
        [Route("api/GetRoulettes")]
        public IEnumerable<Roulette> GetRoulettes()
        {
            List<Roulette> Roulettes = new List<Roulette>();
            Roulettes=RouletteService.GetRoulettes();

            return Roulettes;

        }
        [HttpPost]
        [Route("api/CreateRoulette")]
        public int CreateRoulette([FromBody]string value)
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

        [HttpPost]
        [Route("api/CloseRoulette")]
        public IEnumerable<Bets> CloseBetsxRoulette(Roulette roulette)
        {
            List<Bets> Bets = new List<Bets>();

            Bets = RouletteService.GetBets(roulette.Id);

            return Bets;
        }


    }
}
