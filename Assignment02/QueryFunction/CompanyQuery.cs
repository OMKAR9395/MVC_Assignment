using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Second_Mvc_Application.ExcuteFunction;
using Second_Mvc_Application.Models;
namespace Assignment02.QueryFunction
{
    public class CompanyQuery
    {
        Execute execute = new Execute();
        public DataTable GetCompanyDetails(int Id = 0)
        {
            DataTable dt = new DataTable();
            string Query = "Select * from Company";

            if (Id > 0)
            {
                Query += " where Comp_No=" + Id;
            }
            dt = execute.ExcuteDatatble(Query);

            return dt;
        }
        public int InsertData(CompanyModel Model)
        {
            string query = "Insert Into Company(Comp_Name,Strength,Remarks) values('" + Model.Comp_Name + "'," + Model.Stength + ",";
            query += "'" + Model.Remarks + "') If(@@Error=0) Select 1 else Select 0";
            int Res = execute.Excuteint(query);
            return Res;
        }

        public int UpdateData(CompanyModel Model)
        {
            string query = "Update Company Set Strength= " + Model.Stength + ", Remarks='" + Model.Remarks + "' where COMP_NO=" + Model.Comp_No + "";
            query += " If(@@Error=0) Select 1 else Select 0";

            int Res = execute.Excuteint(query);

            return Res;
        }

        public int DeleteData(int Id)
        {
            string query = "Delete From Company Where Comp_No=" + Id;
            query += " If(@@Error=0) Select 1 else Select 0";

            int Res = execute.Excuteint(query);

            return Res;
        }
    }
}