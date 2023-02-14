using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using OnlineTicketBookingSystem.Models;

namespace OnlineTicketBookingSystem.Repository
{
    public class TicketRepository
    {
        private SqlConnection con;
        //To Handle connection related activities    
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["mycon"].ToString();
            con = new SqlConnection(constr);

        }
        //To Add Employee details    
        public bool AddTicket(Booking obj)
        {

            connection();
            SqlCommand com = new SqlCommand("AddNewTickets", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Moviename", obj.Moviename);
            com.Parameters.AddWithValue("@SeatRow", obj.SeatRow);
            com.Parameters.AddWithValue("@Seatnumber", obj.Seatnumber);
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
        //To view employee details with generic list     
        public List<Booking> GetAllTickets()
        {
            connection();
            List<Booking> TktList = new List<Booking>();


            SqlCommand com = new SqlCommand("GetTickets", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();
            //Bind EmpModel generic list using dataRow     
            foreach (DataRow dr in dt.Rows)
            {

                TktList.Add(

                    new Booking
                    {
                        id = Convert.ToInt32(dr["id"]),
                        Moviename = Convert.ToString(dr["Moviename"]),
                        SeatRow = Convert.ToString(dr["SeatRow"]),
                        Seatnumber = Convert.ToString(dr["Seatnumber"]),
                        Price = Convert.ToDouble(dr["Price"])
                    }
                    );
            }

            return TktList;
        }
    }
}