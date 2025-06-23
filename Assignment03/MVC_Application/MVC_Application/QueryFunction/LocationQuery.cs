using MVC_Application.ExecuteFunction;
using MVC_Application.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MVC_Application.QueryFunction
{
    public class LocationQuery
    {
        Execute execute = new Execute();
        public int Insertdata(LocationModel Model)
        {
            string query = "Insert Into Location(LocName,Remarks,CompNo)values('" + Model.LocName + "','" + Model.Remarks + "',";
            query += "  " + Model.CompNo + ") If(@@Error=0) Select @@Identity else Select 0";
            int Res = execute.Excuteint(query);

            return Res;
        }

        public DataTable GetLocationDetails(int Id = 0)
        {
            string query = "Select* from Location Loc inner join Compony Com on Com.Comp_No = Loc.CompNo";

            if (Id > 0)
            {
                query += " where LocNo=" + Id;
            }

            DataTable dt = execute.ExcuteDatatble(query);

            return dt;
        }

        public int Updatedata(LocationModel Model)
        {
            string query = "Update Location Set LocName='" + Model.LocName + "',Remarks='" + Model.Remarks + "',CompNo ='" + Model.CompNo + "'";
            query += " where LocNo=" + Model.LocNo + " if(@@Error=0) Select 1 else Select 0";
            int Res = execute.Excuteint(query);

            return Res;
        }

        public int DeleteData(int Id)
        {
            string query = "Delete From Location Where LocNo=" + Id;
            query += "If(@@Error=0) Select 1 else select 0";

            return execute.Excuteint(query);
        }
    }
}