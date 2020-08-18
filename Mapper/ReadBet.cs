using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using TestRoulette.Models;

namespace TestRoulette.Mapper
{
    public class ReadBet : Bets
    {
        public int Id { get; set; }
        public int Roulette_Id { get; set; }
        public int User_Id { get; set; }
        public string Bet { get; set; }
        public DateTime Bet_Date { get; set; }
        public int Price { get; set; }

        public ReadBet(DataRow row)
        {
            Id= Convert.ToInt32(row["Id"]);
            Roulette_Id= Convert.ToInt32(row["Roulette_Id"]);
            User_Id= Convert.ToInt32(row["User_Id"]);
            Bet = Convert.ToString(row["Bet"]);
            Bet_Date = Convert.ToDateTime(row["Bet_Date"]);
            Price = Convert.ToInt32(row["Price"]);
        }       

    }
}