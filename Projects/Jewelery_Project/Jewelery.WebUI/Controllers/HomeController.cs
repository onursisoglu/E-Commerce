using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jewelery.BLL.Repository;


namespace Jewelery.WebUI.Controllers
{
    using BLL.BO;
    using Jewelry.DTO.Model.ViewModels;

    public class HomeController : Controller
    {
        Home homeOperations = new Home();
        // GET: Home
        public ActionResult Index()
        {
           
            return View();
        }
        public ActionResult PartialCategories()
        {
            return View("_NavCategories",homeOperations.Categories());
        }
        public ActionResult hebel()
        {
            
            return PartialView("_productTable",homeOperations.OpportunityProducts());
        }
    }
}