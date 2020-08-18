using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestRoulette.Models
{
    public class Roulette
    {
        public int Id { get; set; }
        public DateTime Opening_Date { get; set; }
        public DateTime Closing_Date { get; set; }
        public bool State { get; set; }

    }
}