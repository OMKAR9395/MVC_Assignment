using Second_Mvc_Application.ExcuteFunction;
using Second_Mvc_Application.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
namespace Assignment02.QueryFunction
{
    public class LocationQuerry
    {
        Execute execute = new Execute();
        public int Insertdata(LocationModel Model)
        {
            string query = "Insert Into Location(LocName,Remarks,CompNo)values('" + Model.LocName + "','" + Model.Remarks + "',";
            query += "  " + Model.CompNo + ") If(@@Error=0) Select @@Identity else Select 0";
            int Res = execute.Excuteint(query);

            return Res;
        }
    }
}