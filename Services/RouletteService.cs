using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TestRoulette.Mapper;


namespace TestRoulette.Models.Services
{
    public class RouletteService
    {

        private static SqlConnection _conn;
        private static SqlDataAdapter _adp;

        public static List<Roulette> GetRoulettes()
        {
            _conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Roul"].ToString());
            DataTable data = new DataTable();
            var query = "select * from Roulettes";
            _adp = new SqlDataAdapter
            {
                SelectCommand = new SqlCommand(query, _conn)
            };
            _adp.Fill(data);
            List<Roulette> Roulettes = new List<Roulette>(data.Rows.Count);
            if(data.Rows.Count>0)
            {
                foreach (DataRow roulette in data.Rows)
                {
                    Roulettes.Add(new ReadRoulette(roulette));
                }
            }

            return Roulettes;
        }


        public void CreateRoulette()
        {
            _conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Roul"].ToString());


            var query = new String("insert into Roulettes values ("{0}",null,1)",new DateTime)


        }





    }
}