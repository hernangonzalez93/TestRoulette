using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using TestRoulette.Models;

namespace TestRoulette.Mapper
{
    public class ReadRoulette : Roulette
    {
        public ReadRoulette(DataRow row)
        {
            Id = Convert.ToInt32(row["Id"]);
            Opening_Date = Convert.ToDateTime(row["Opening_Date"]);
            Closing_Date = Convert.ToDateTime(row["Closing_Date"]);
            State = Convert.ToBoolean(row["State"]);


        }
        public int Id { get; set; }
        public DateTime Opening_Date { get; set; }
        public DateTime Closing_Date { get; set; }
        public bool State { get; set; }
    }
}