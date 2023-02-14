using OnlineTicketBookingSystem.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;

namespace OnlineTicketBookingSystem.Repository
{
    public class ImagesRepository
    {
        private SqlConnection Con;

        //To Handle connection related activities
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["mycon"].ToString();
            Con = new SqlConnection(constr);
        }
        //get user details

        public List<ImagesMovie> GetImages()
        {
            connection();
            List<ImagesMovie> Imageslist = new List<ImagesMovie>();
            SqlCommand com = new SqlCommand("GetImage", Con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            Con.Open();
            da.Fill(dt);
            Con.Close();



            foreach (DataRow dr in dt.Rows)
                Imageslist.Add(
                    new ImagesMovie
                    {
                        id = Convert.ToInt32(dr["id"]),
                        MovieImage = Convert.ToString(dr["MovieImage"]),
                        Description = Convert.ToString(dr["Description"]),
                        Name = Convert.ToString(dr["Name"]),
                    }
                    );
            return Imageslist;
        }
        public bool EditImages(ImagesMovie obj)
        {
            connection();
            SqlCommand com = new SqlCommand("UpdateImage", Con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@id", obj.id);
            com.Parameters.AddWithValue("@MovieImage", obj.MovieImage);
            com.Parameters.AddWithValue("@Description", obj.Description);
            com.Parameters.AddWithValue("@Name", obj.Name);
            Con.Open();
            int i = com.ExecuteNonQuery();
            Con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool DeleteImages(int id)
        {
            connection();
            SqlCommand com = new SqlCommand("DeleteImageById", Con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("id", id);

            Con.Open();
            int i = com.ExecuteNonQuery();
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