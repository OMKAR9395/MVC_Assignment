using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace Demo.ExecuteFunction
{
    public class Common
    {
        public string Constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();

        public DataTable ExecuteTable(string query)
        {
            DataTable dt = new DataTable();

            SqlConnection Con = new SqlConnection(Constr);

            SqlDataAdapter da = new SqlDataAdapter(query, Con);

            da.Fill(dt);

            return (dt);
        }

        public int Executeint(string query)
        {
            SqlConnection Con = new SqlConnection(Constr);

            Con.Open();
            SqlCommand cmd = new SqlCommand(query, Con);

            int Result = Convert.ToInt32(cmd.ExecuteScalar());

            Con.Close();

            return (Result);
        }
        }
        //    public class Common
        //{
        //    string Constr = @"Data Source=PATIL\MSSQLSERVER01;Initial Catalog=Assignment01_Employee_Details_DB;Integrated Security=True;";

        //    public DataTable ExecuteTable(string query)
        //    {
        //        DataTable dt = new DataTable();
        //        using (SqlConnection Con = new SqlConnection(Constr))
        //        {
        //            try
        //            {
        //                SqlDataAdapter da = new SqlDataAdapter(query, Con);
        //                da.Fill(dt);
        //            }
        //            catch (Exception ex)
        //            {
        //                Console.WriteLine("Connection failed: " + ex.Message);
        //                throw;
        //            }
        //        }
        //        return dt;
        //    }
        //}

    }