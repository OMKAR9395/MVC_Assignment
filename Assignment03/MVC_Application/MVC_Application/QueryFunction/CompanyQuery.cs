using MVC_Application.ExecuteFunction;
using MVC_Application.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MVC_Application.QueryFunction
{
    public class CompanyQuery
    {

        Execute execute = new Execute();
        public DataTable GetCompanyDetails(int Id = 0)
        {
            DataTable dt = new DataTable();
            string Query = "Select * from Compony";

            if (Id > 0)
            {
                Query += " where Comp_No=" + Id;
            }
            dt = execute.ExcuteDatatble(Query);

            return dt;
        }

        public int InsertData(CompanyModel Model)
        {
            string query = "Insert Into Compony(Comp_Name,Strength,Remarks) values('" + Model.Comp_Name + "'," + Model.Strength + ",";
            query += "'" + Model.Remark + "') If(@@Error=0) Select 1 else Select 0";

            int Res = execute.Excuteint(query);
            return Res;
        }

        public int UpdateData(CompanyModel Model)
        {
            string query = "Update Compony Set Strength= " + Model.Strength + ", Remarks='" + Model.Remark + "' where COMP_NO=" + Model.Comp_No + "";
            query += " If(@@Error=0) Select 1 else Select 0";

            int Res = execute.Excuteint(query);

            return Res;
        }

        public int DeleteData(int Id)
        {
            string query = "Delete From Compony Where Comp_No=" + Id;
            query += " If(@@Error=0) Select 1 else Select 0";

            int Res = execute.Excuteint(query);

            return Res;
        }
    }
}