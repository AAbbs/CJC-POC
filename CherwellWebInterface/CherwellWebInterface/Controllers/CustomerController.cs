using CherwellApi;
using CherwellWebInterface.Models;
using Classes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CherwellWebInterface.Controllers
{
    public class CustomerController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            List<Company> companies = CherwellSoapInterface.GetAllCompanies();

            return View(companies);
        }
        
        [HttpPost]
        public IActionResult Index(CustomerViewModel customerViewModel)
        {            
            return View(customerViewModel);
        }
        /*
        [HttpGet]
        public ActionResult Create()
        {
            var company = new Company();
            return View(company);
        }*/
        
        [HttpPost]
        public ActionResult Create(Company company)
        {
            if (ModelState.IsValid)
            {
                CherwellSoapInterface.UpdateCompany(company);
            }
            return PartialView(company);
        }

        [HttpGet]
        public ActionResult Create(string recId)
        {
            Company company;
            if (recId != null && recId != "")
            {
                company = CherwellSoapInterface.GetCompany(recId);
            }
            else
            {
                company = new Company();
            }
            return PartialView(company);
        }
    }
}
