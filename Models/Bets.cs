using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestRoulette.Models
{
    public class Bets
    {
        public int Id { get; set; }
        public int Roulette_Id { get; set; }
        public int User_Id { get; set; }
        public string Bet { get; set; }
        public DateTime Bet_Date { get; set; }
        public int Price { get; set; }

    }
}