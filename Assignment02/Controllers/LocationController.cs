using Assignment02.Models;
using Assignment02.QueryFunction;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment02.Controllers
{
    public class LocationController : Controller
    {
        // GET: Location
        public ActionResult Index()
        {
            List<LocationModel> ListModel = new List<LocationModel>();
            return View(ListModel);
        }

        // GET: Location/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Location/Create
        public ActionResult Create()
        {
            ViewBag.Company = LoadCompany();
            return View();
        }

        // POST: Location/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            LocationModel model = new LocationModel();
            try
            {
                // TODO: Add insert logic here

                model.CompNo = Convert.ToInt32(collection["CompName"]);
                model.LocName = Convert.ToString(collection["LocName"]);
                model.Remarks = Convert.ToString(collection["Remarks"]);

                LocationQuery Location = new LocationQuery();
                int Res = Location.Insertdata(model);

                if (Res > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }

            return View(model);
        }

        // GET: Location/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Location/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Location/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Location/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public List<SelectListItem> LoadCompany(int CompNo = 0)
        {
            List<SelectListItem> LisCompany = new List<SelectListItem>();

            CompanyQuery company = new CompanyQuery();
            DataTable dt = company.GetCompanyDetails();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    LisCompany.Add(new SelectListItem()
                    {
                        Text = Convert.ToString(dr["Comp_Name"]),
                        Value = Convert.ToString(dr["COMP_NO"]),
                        Selected = CompNo == Convert.ToInt32(dr["COMP_NO"])
                    });
                }
            }
            return LisCompany;
        }
    }
}