using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Second_Mvc_Application.ExcuteFunction
{
    public class Execute
    {
        public string Constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();

        public DataTable ExcuteDatatble(string query)
        {
            DataTable dt = new DataTable();

            SqlConnection Con = new SqlConnection(Constr);

            SqlDataAdapter adpter = new SqlDataAdapter(query, Con);

            adpter.Fill(dt);

            return dt;
        }

        public int Excuteint(string query)
        {
            SqlConnection Con = new SqlConnection(Constr);
            Con.Open();
            SqlCommand cmd = new SqlCommand(query, Con);

            int Result = Convert.ToInt32(cmd.ExecuteScalar());

            Con.Close();
            return Result;
        }
    }
}