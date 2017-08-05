using Jewelery.BLL.BO.Admin;
using Jewelery.BLL.Extensions;
using Jewelery.WebUI.Controllers;
using Jewelry.DTO.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jewelery.WebUI.Areas.Admin.Controllers
{
    public class AdminHomeController : BaseController
    {
        HomeAdmin adminOperation = new HomeAdmin();
        // GET: Admin/AdminHome
        public ActionResult Index()
        {
            if (Session["Admin"] == null)
            {
                return RedirectToAction("Index", "AdminLogin");

            }

            return View();
        }

        public ActionResult DataList(string text)
        {

            switch (text)
            {
                case "Product":
                    return PartialView("_productList", adminOperation.AdminIndex(text));
                case "Category":
                    return PartialView("_categoryList", adminOperation.AdminIndex(text));
                case "Customer":
                    return PartialView("_customerList", adminOperation.AdminIndex(text));
                case "Gem":
                    return PartialView("_gemList", adminOperation.AdminIndex(text));
                case "Order":
                    return PartialView("_orderList", adminOperation.AdminIndex(text));
                case "SubCategory":
                    return PartialView("_subCategoryList", adminOperation.AdminIndex(text));
                case "CategoryChart":
                    return PartialView("_categoryChart");
                default:
                    return null;

            }
        }
        // !--- CATEGORY CRUD START 
        public ActionResult AddCategory()
        {
            return PartialView("_addCategory");
        }
        [HttpPost]
        public ActionResult AddCategory(FormCollection fc)
        {
            //string name = fc["name"];
            //string description = fc["description"];
            CategoryDTO category = new CategoryDTO();
            category.CategoryName = fc["name"];
            category.Description = fc["description"];
            return Json(adminOperation.AddCategory(category), JsonRequestBehavior.AllowGet);
        }
        public ActionResult CategoryUpdate(int CategoryID)
        {

            return PartialView("_updateCategory", adminOperation.UpdateCategoryView(CategoryID));
        }
        [HttpPost]
        public ActionResult CategoryUpdate(FormCollection fc, int CategoryID)
        {
            CategoryDTO updateCategory = new CategoryDTO();
            updateCategory.CategoryID = CategoryID;
            updateCategory.CategoryName = fc["name"];
            updateCategory.Description = fc["description"];
            updateCategory.IsActive =Convert.ToBoolean( fc["isactive"]);

            return Json(adminOperation.UpdateCategory(updateCategory), JsonRequestBehavior.AllowGet);
        }
        public ActionResult CategoryDelete(int CategoryID)
        {

            return Json(adminOperation.DeleteCategory(CategoryID), JsonRequestBehavior.AllowGet);
        }
        // CATEGORY CRUD END ---!

        public ActionResult GemAdd()
        {
            return PartialView("_addGem");
        }
        [HttpPost]
        public ActionResult GemAdd(FormCollection fc)
        {
            GemDTO newGem = new GemDTO();
            newGem.GemName = fc["name"];
            newGem.Colour = fc["colour"];
            newGem.GemWeight = Convert.ToDecimal(fc["weight"]);
            newGem.Shape = fc["shape"];

            return Json(adminOperation.AddGem(newGem), JsonRequestBehavior.AllowGet);
        }
        public ActionResult GemUpdate(int GemID)
        {
            return PartialView("_updateGem",adminOperation.GemUpdateView(GemID));
        }
        [HttpPost]
        public ActionResult GemUpdate(FormCollection fc, int GemID)
        {
            GemDTO updateGem = new GemDTO();
            updateGem.GemID = GemID;
            updateGem.GemName = fc["name"];
            updateGem.GemWeight =Convert.ToDecimal(fc["description"]);
            updateGem.Shape = fc["shape"];
            updateGem.Colour = fc["colour"];

            return Json(adminOperation.GemUpdate(updateGem),JsonRequestBehavior.AllowGet);
        }

        public ActionResult GemDelete(int GemID)
        {
            return Json(adminOperation.DeleteGem(GemID), JsonRequestBehavior.AllowGet);
        }


        public ActionResult AddresDetail(int CustomerID)
        {
            return PartialView("_customerAddressDetail", adminOperation.CustomerDetail(CustomerID));
        }

        public ActionResult OrderDetail(int OrderID)
        {
            return PartialView("_orderDetail", adminOperation.OrderDetail(OrderID));
        }

        public ActionResult CategoryChart()
        {
            return View();
        }
        public ActionResult ProductChart()
        {
            return View();
        }
    }
}