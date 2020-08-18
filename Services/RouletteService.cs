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


        public static int CreateRoulette()
        {
            _conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Roul"].ToString());
            DateTime OpenDate = DateTime.Now;
            var query = "insert into Roulettes (Opening_Date,Closing_Date,State) values (@Opening_Date,@Closing_Date,@State)";
            SqlCommand InsertCommand = new SqlCommand(query, _conn);
            InsertCommand.Parameters.AddWithValue("@Opening_Date",OpenDate);
            InsertCommand.Parameters.AddWithValue("@Closing_Date", ' ');
            InsertCommand.Parameters.AddWithValue("@State", 0);
            _conn.Open();
            int result = InsertCommand.ExecuteNonQuery();
            if(result >0)
            {
                var rouletteidquery = "select MAX(id) from Roulettes";
                DataSet ds = new DataSet();
                _adp = new SqlDataAdapter {
                    SelectCommand = new SqlCommand(rouletteidquery, _conn)
                };
                _adp.Fill(ds);
                DataRow row = ds.Tables[0].Rows[0];
                var ids = row.ItemArray[0];
           
                return (int)ids;
            }
            else
            {
                return 0;
            }
            _conn.Close();
        }





    }
}