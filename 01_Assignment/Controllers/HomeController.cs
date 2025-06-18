using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.Mvc;
using Demo.DatabaseQuery;
using Demo.Models;

namespace Demo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            QueryFunction queryFunction = new QueryFunction();

            queryFunction.GetComponyDetails();

            DataTable dt = queryFunction.GetComponyDetails();
            List<Compony> Listcompony = new List<Compony>();

            if(dt.Rows.Count>0)
            {
                foreach(DataRow dr in dt.Rows)
                {
                    Compony compony = new Compony();
                    compony.Id = Convert.ToInt32( dr["Id"]);
                    compony.ComponyName = dr["Name"].ToString();
                    compony.Address = dr["Address"].ToString();
                    compony.Remark = dr["Remark"].ToString();
                    Listcompony.Add(compony);
                }
            }
            return View(Listcompony);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Edit()
        {
            Compony objCom = new Compony();
            objCom.ComponyName = "Infosys";
            objCom.Address = "Pune";
            objCom.Remark = "Good Service";
            return View(objCom);
        }
        [HttpPost]
        public ActionResult Edit(FormCollection collection)
        {
            return View();
        }
        [HttpGet]
        public ActionResult Details()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Delete(FormCollection collection)
        {
            return View();
        }
        public void FillDataTable()
        {
            QueryFunction queryFunction = new QueryFunction();

            queryFunction.GetComponyDetails();
        }
    }
}