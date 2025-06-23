using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Application.Models;
using MVC_Application.QueryFunction;

namespace MVC_Application.Controllers
{
    public class CompanyController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            CompanyQuery company = new CompanyQuery();
            DataTable dt = company.GetCompanyDetails();
            List<CompanyModel> listModel = new List<CompanyModel>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    CompanyModel companyModel = new CompanyModel();

                    companyModel.Comp_No = Convert.ToInt32(dr["Comp_No"]);
                    companyModel.Comp_Name = Convert.ToString(dr["Comp_Name"]);
                    companyModel.Strength = Convert.ToInt32(dr["Strength"]);
                    companyModel.Remark = Convert.ToString(dr["Remarks"]);

                    listModel.Add(companyModel);
                }
            }
            return View(listModel);
        }
        [HttpGet]
        public ActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            CompanyModel companyModel = new CompanyModel();
            companyModel.Comp_Name = Convert.ToString(collection["Comp_Name"]);

            if (!string.IsNullOrWhiteSpace(collection["Strength"]))
            {
                companyModel.Strength = Convert.ToInt32(collection["Strength"]);
            }
            
            companyModel.Remark = Convert.ToString(collection["Remark"]);

            //if(companyModel.Comp_Name != null && companyModel.Comp_Name != "")
            //{
            //    ModelState.AddModelError("Comp_Name", "Please Enter Company");
            //}
            if(string.IsNullOrWhiteSpace(companyModel.Comp_Name))
            {
                ModelState.AddModelError("Comp_Name", "Please Enter Company");
            }

            CompanyQuery company = new CompanyQuery();

            if(ModelState.IsValid)
            {
                int res = company.InsertData(companyModel);

                if (res > 0)
                {
                    TempData["Messege"] = "Data Inserted Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(companyModel);
                }

            }
            return View(companyModel);


        }
        [HttpGet]
        public ActionResult Edit(int  Id = 0)
        {
            CompanyModel model = FillCompanyDetails(Id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(FormCollection collection)
        {
            CompanyModel companyModel = new CompanyModel();
            companyModel.Comp_Name = Convert.ToString(collection["Comp_Name"]);
            companyModel.Comp_No = Convert.ToInt32(collection["Comp_No"]);
            if (!string.IsNullOrWhiteSpace(collection["Strength"]))
            {
                companyModel.Strength = Convert.ToInt32(collection["Strength"]);
            }
            companyModel.Remark = Convert.ToString(collection["Remark"]);

            if (string.IsNullOrWhiteSpace(companyModel.Comp_Name))
            {
                ModelState.AddModelError("Comp_Name", "Please Enter Company");
            }
            CompanyQuery company = new CompanyQuery();
            if (ModelState.IsValid)
            {
                int Res = company.UpdateData(companyModel);
                if (Res > 0)
                {
                    TempData["Message"] = "Data Updated Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(companyModel);
                }
            }
            return View(companyModel);
        }

        public ActionResult Delete(int Id = 0)
        {
            CompanyModel model = FillCompanyDetails(Id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(FormCollection collection)
        {
            int CompNo = Convert.ToInt32(collection["Comp_No"]);
            CompanyQuery company = new CompanyQuery();
            int Res = company.DeleteData(CompNo);

            if (Res > 0)  
            {
                TempData["Message"] = "Data Delete Successfully";
                return RedirectToAction("Index");
            }
            else
            {
                CompanyModel companyModel = FillCompanyDetails(CompNo);
                return View(companyModel);
            }
        }
        public ActionResult Details(int Id = 0)
        {
            CompanyModel model = FillCompanyDetails(Id);

            return View(model);
        }

        public static CompanyModel FillCompanyDetails(int Id)
        {
            CompanyModel model = new CompanyModel();

            CompanyQuery company = new CompanyQuery();
            DataTable dt = company.GetCompanyDetails(Id);

            if (dt.Rows.Count > 0)
            {
                model.Comp_No = Convert.ToInt32(dt.Rows[0]["Comp_No"]);
                model.Comp_Name = Convert.ToString(dt.Rows[0]["Comp_Name"]);
                model.Strength = Convert.ToInt32(dt.Rows[0]["Strength"]);
                model.Remark = Convert.ToString(dt.Rows[0]["Remarks"]);
            }
            return model;
        }
    }
}