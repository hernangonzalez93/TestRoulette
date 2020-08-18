using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
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
            var query = "insert into Roulettes (Opening_Date,Closing_Date,State) values (@Opening_Date,@Closing_Date,@State)";
            SqlCommand InsertCommand = new SqlCommand(query, _conn);
            InsertCommand.Parameters.AddWithValue("@Opening_Date",' ');
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


        public static int OpenRoulette(int id)
        {
            DateTime OpenRouletteTime = DateTime.Now;
            _conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Roul"].ToString());
            var query = "update Roulettes set Opening_Date = @Opening_Date ,State = @State where Id= @id";
            SqlCommand UpdateCommand = new SqlCommand(query, _conn);
            UpdateCommand.Parameters.AddWithValue("@Opening_Date",OpenRouletteTime);
            UpdateCommand.Parameters.AddWithValue("@State",1);
            UpdateCommand.Parameters.AddWithValue("@id", id);
            _conn.Open();
            int result = UpdateCommand.ExecuteNonQuery();
            if (result > 0)
            {
                return result;
            }
            else           
            { 
              return  0;
            }

        }

        public static int CreateBet(Bets bet)
        {
            _conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Roul"].ToString());
            var query = "insert into Bets (Roulette_Id,User_Id,Bet,Bet_Date,Price) values (@Roulette_Id,@User_Id,@Bet,@Bet_Date,@Price)";
            SqlCommand InsertCommand = new SqlCommand(query, _conn);
            InsertCommand.Parameters.AddWithValue("@Roulette_Id", bet.Roulette_Id );
            InsertCommand.Parameters.AddWithValue("@User_Id", bet.User_Id);
            InsertCommand.Parameters.AddWithValue("@Bet", bet.Bet);
            InsertCommand.Parameters.AddWithValue("@Bet_Date", bet.Bet_Date);
            InsertCommand.Parameters.AddWithValue("@Price", bet.Price);
            _conn.Open();
            int result = InsertCommand.ExecuteNonQuery();
            if (result > 0)
            {
                return result;
            }
            else
            {
                return 0;
            }

        }




    }
}