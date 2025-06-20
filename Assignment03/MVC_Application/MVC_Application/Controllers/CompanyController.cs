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

            if (!string.IsNullOrWhiteSpace(collection["Stength"]))
            {
                companyModel.Strength = Convert.ToInt32(collection["Stength"]);
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
        public ActionResult Edit(int?  Id = 0)
        {
            return View();
        }


        public ActionResult Delete(int? Id = 0)
        {
            return View();
        }

        public ActionResult Details(int? Id = 0)
        {
            return View();
        }
    }
}