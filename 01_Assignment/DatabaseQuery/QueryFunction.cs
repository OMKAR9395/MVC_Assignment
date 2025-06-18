using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Demo.ExecuteFunction;
namespace Demo.DatabaseQuery
{
    public class QueryFunction
    {
        public DataTable GetComponyDetails()
        {
            Common objCom = new Common();

            string query = "Select * From tbl_Compony";
            DataTable dt = objCom.ExecuteTable(query);

            return dt;

        }
    }
}