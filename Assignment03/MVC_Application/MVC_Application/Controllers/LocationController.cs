using MVC_Application.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Application.QueryFunction;


namespace MVC_Application.Controllers
{
    public class LocationController : Controller
    {
        // GET: Location
        public ActionResult Index()
        {
            List<LocationModel> ListModel = new List<LocationModel>();
            LocationQuery query = new LocationQuery();

            DataTable dt = query.GetLocationDetails();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    LocationModel locationModel = new LocationModel();

                    locationModel.LocNo = Convert.ToInt32(dr["LocNo"]);
                    locationModel.LocName = Convert.ToString(dr["LocName"]);
                    locationModel.Remarks = Convert.ToString(dr["Remarks"]);

                    locationModel.CompName = Convert.ToString(dr["Comp_name"]);

                    ListModel.Add(locationModel);
                }
            }
            return View(ListModel);
        }

        // GET: Location/Details/5
        public ActionResult Details(int id)
        {
            LocationModel locationModel = FillLocationDetails(id);
            ViewBag.Company = LoadCompany(locationModel.CompNo);
            return View(locationModel);
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
                    TempData["Message"] = "Data Inserted Sucessfuly";
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
            LocationModel locationModel = FillLocationDetails(id);
            ViewBag.Company = LoadCompany(locationModel.CompNo);
            return View(locationModel);
        }

        // POST: Location/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            LocationModel model = new LocationModel();
            try
            {
                // TODO: Add insert logic here
                model.LocNo = id;
                model.CompNo = Convert.ToInt32(collection["CompName1"]);
                model.LocName = Convert.ToString(collection["LocName"]);
                model.Remarks = Convert.ToString(collection["Remarks"]);

                LocationQuery Location = new LocationQuery();
                int Res = Location.Updatedata(model);

                if (Res > 0)
                {
                    TempData["Message"] = "Data Update Sucessfuly";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Message"] = "Data Update Faild";
                }
            }
            catch
            {
                return View();
            }
            model = FillLocationDetails(id);
            ViewBag.Company = LoadCompany(model.CompNo);
            return View(model);
        }

        // GET: Location/Delete/5
        public ActionResult Delete(int id)
        {
            LocationModel locationModel = FillLocationDetails(id);
            ViewBag.Company = LoadCompany(locationModel.CompNo);
            return View(locationModel);
        }

        // POST: Location/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                LocationQuery query = new LocationQuery();
                if (query.DeleteData(id) > 0)
                {
                    TempData["Message"] = "Delete Data Successfull";
                    return RedirectToAction("Index");
                }
                else
                {
                    LocationModel locationModel = FillLocationDetails(id);
                    ViewBag.Company = LoadCompany(locationModel.CompNo);
                    return View(locationModel);
                }
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
                        Selected = (Convert.ToInt32(dr["Comp_No"]) == CompNo)
                    });
                }
            }
            return LisCompany;
        }

        public LocationModel FillLocationDetails(int Id)
        {
            LocationModel locationModel = new LocationModel();

            LocationQuery query = new LocationQuery();

            DataTable dt = query.GetLocationDetails(Id);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    locationModel.LocNo = Convert.ToInt32(dr["LocNo"]);
                    locationModel.LocName = Convert.ToString(dr["LocName"]);
                    locationModel.Remarks = Convert.ToString(dr["Remarks"]);
                    locationModel.CompName = Convert.ToString(dr["Comp_Name"]);
                    locationModel.CompNo = Convert.ToInt32(dr["CompNo"]);
                }
            }
            return locationModel;
        }
    }

}
