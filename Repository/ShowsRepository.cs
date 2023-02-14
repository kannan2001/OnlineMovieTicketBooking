using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using OnlineTicketBookingSystem.Models;

namespace OnlineTicketBookingSystem.Repository
{
    public class ShowsRepository
    {
        private SqlConnection con;
        //To Handle connection related activities    
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["mycon"].ToString();
            con = new SqlConnection(constr);
        }
        //To Add Show details    
        public bool AddShows(MovieShows obj)
        {

            connection();
            SqlCommand com = new SqlCommand("AddNewShowDetails", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@MovieName", obj.MovieName);
            com.Parameters.AddWithValue("@ScreenNo", obj.ScreenNo);
            com.Parameters.AddWithValue("@Date", obj.Date);
            com.Parameters.AddWithValue("@StartTime", obj.StartTime);
            com.Parameters.AddWithValue("@Price", obj.Price);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {

                return true;

            }
            else
            {

                return false;
            }
        }
        //To view show details with generic list
        public List<MovieShows> GetAllShows()
        {
            connection();
            List<MovieShows> ShowsList = new List<MovieShows>();


            SqlCommand com = new SqlCommand("GetShows", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();
            //Bind EmpModel generic list using dataRow     
            foreach (DataRow dr in dt.Rows)
            {

                ShowsList.Add(

                    new MovieShows
                    {

                        Showid = Convert.ToInt32(dr["Showid"]),
                        MovieName = Convert.ToString(dr["MovieName"]),
                        ScreenNo = Convert.ToInt32(dr["ScreenNo"]),
                        Date = Convert.ToDateTime(dr["Date"]),
                        StartTime= Convert.ToDateTime(dr["StartTime"]),
                        Price = Convert.ToDouble(dr["Price"])

                    }
                    );
            }

            return ShowsList;
        }
        //To Update Show details
        public bool UpdateShows(MovieShows obj)
        {

            connection();
            SqlCommand com = new SqlCommand("UpdateShowDetails", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Showid", obj.Showid);
            com.Parameters.AddWithValue("@MovieName", obj.MovieName);
            com.Parameters.AddWithValue("@ScreenNo", obj.ScreenNo);
            com.Parameters.AddWithValue("@Date", obj.Date);
            com.Parameters.AddWithValue("@StartTime", obj.StartTime);
            com.Parameters.AddWithValue("@Price", obj.Price);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {

                return true;
            }
            else
            {
                return false;
            }
        }
        //To delete Show details    
        public bool DeleteShows(int Id)
        {

            connection();
            SqlCommand com = new SqlCommand("DeleteShowsById", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Showid", Id);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {

                return false;
            }
        }
    }
}
