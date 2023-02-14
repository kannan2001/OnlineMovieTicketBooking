using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineTicketBookingSystem.Models;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace OnlineTicketBookingSystem.Repository
{
    public class UserRepository
    {
        private SqlConnection con;
        private void Connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["mycon"].ToString();
            con = new SqlConnection(constr);
        }
        public bool InsertData(UserAccount objuser)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Customer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FirstName", objuser.FirstName);
            cmd.Parameters.AddWithValue("@LastName", objuser.LastName);
            cmd.Parameters.AddWithValue("@MobNumber", objuser.MobNumber);
            cmd.Parameters.AddWithValue("@Birthdate", objuser.Birthdate);
            cmd.Parameters.AddWithValue("@Username", objuser.Username);
            cmd.Parameters.AddWithValue("@Password", objuser.Password);
            cmd.Parameters.AddWithValue("@Query", 1);
            con.Open();
            int i = cmd.ExecuteNonQuery();
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
        public string UpdateData(UserAccount objuser)
        {
            string result = "";
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Customer", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserID", objuser.UserID);
                cmd.Parameters.AddWithValue("@FirstName", objuser.FirstName);
                cmd.Parameters.AddWithValue("@LastName", objuser.LastName);
                cmd.Parameters.AddWithValue("@MobNumber", objuser.MobNumber);
                cmd.Parameters.AddWithValue("@Birthdate", objuser.Birthdate);
                cmd.Parameters.AddWithValue("@Username", objuser.Username);
                cmd.Parameters.AddWithValue("@Password", objuser.Password);
                cmd.Parameters.AddWithValue("@Query", 2);
                con.Open();
                result = cmd.ExecuteScalar().ToString();
                return result;
            }
            catch
            {
                return result = "";
            }
            finally
            {
                con.Close();
            }
        }
        public int DeleteData(String ID)
        {
            int result;
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Customer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", ID);
                cmd.Parameters.AddWithValue("@FirstName", null);
                cmd.Parameters.AddWithValue("@LastName", null);
                cmd.Parameters.AddWithValue("@MobNumber", null);
                cmd.Parameters.AddWithValue("@Birthdate", null);
                cmd.Parameters.AddWithValue("@Username", null);
                cmd.Parameters.AddWithValue("@Password", null);
                cmd.Parameters.AddWithValue("@Query", 3);
                con.Open();
                result = cmd.ExecuteNonQuery();
                return result;
            }
            catch
            {
                return result = 0;
            }
            finally
            {
                con.Close();
            }
        }
        public List<UserAccount> Selectalldata()
        {
            Connection();
            List<UserAccount> userlist = null;
            try
            {
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Customer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", null);
                cmd.Parameters.AddWithValue("@FirstName", null);
                cmd.Parameters.AddWithValue("@LastName", null);
                cmd.Parameters.AddWithValue("@MobNumber", null);
                cmd.Parameters.AddWithValue("@Birthdate", null);
                cmd.Parameters.AddWithValue("@Username", null);
                cmd.Parameters.AddWithValue("@Password", null);
                cmd.Parameters.AddWithValue("@Query", 4);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds);
                userlist = new List<UserAccount>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    UserAccount cobj = new UserAccount();
                    cobj.UserID = Convert.ToInt32(ds.Tables[0].Rows[i]["UserID"].ToString());
                    cobj.FirstName = ds.Tables[0].Rows[i]["FirstName"].ToString();
                    cobj.LastName = ds.Tables[0].Rows[i]["LastName"].ToString();
                    cobj.MobNumber = ds.Tables[0].Rows[i]["MobNumber"].ToString();
                    cobj.Birthdate = Convert.ToDateTime(ds.Tables[0].Rows[i]["Birthdate"].ToString());
                    cobj.Username = ds.Tables[0].Rows[i]["Username"].ToString();
                    cobj.Password = ds.Tables[0].Rows[i]["Password"].ToString(); ;

                    userlist.Add(cobj);
                }
                return userlist;
            }
            catch
            {
                return userlist;
            }
            finally
            {
                con.Close();
            }
        }

        public UserAccount SelectDatabyID(string UserID)
        {
            SqlConnection con = null;
            DataSet ds = null;
            UserAccount cobj = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Customer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", UserID);
                cmd.Parameters.AddWithValue("@FirstName", null);
                cmd.Parameters.AddWithValue("@LastName", null);
                cmd.Parameters.AddWithValue("@MobNumber", null);
                cmd.Parameters.AddWithValue("@Birthdate", null);
                cmd.Parameters.AddWithValue("@Username", null);
                cmd.Parameters.AddWithValue("@Password", null);
                cmd.Parameters.AddWithValue("@Query", 5);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    cobj = new UserAccount();
                    cobj.UserID = Convert.ToInt32(ds.Tables[0].Rows[i]["CustomerID"].ToString());
                    cobj.FirstName = ds.Tables[0].Rows[i]["FirstName"].ToString();
                    cobj.LastName = ds.Tables[0].Rows[i]["LastName"].ToString();
                    cobj.MobNumber = ds.Tables[0].Rows[i]["MobNumber"].ToString();
                    cobj.Birthdate = Convert.ToDateTime(ds.Tables[0].Rows[i]["Birthdate"].ToString());
                    cobj.Username = ds.Tables[0].Rows[i]["Username"].ToString();
                    cobj.Password = ds.Tables[0].Rows[i]["Password"].ToString();
                }
                return cobj;
            }
            catch
            {
                return cobj;
            }
            finally
            {
                con.Close();
            }
        }
    }
}