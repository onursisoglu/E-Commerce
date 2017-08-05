using Jewelery.BLL.BO.Admin;
using Jewelery.BLL.Extensions;

using Jewelery.WebUI.Controllers;
using Jewelry.DTO.Model.DTO;
using Jewelry.DTO.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jewelery.WebUI.Areas.Admin.Controllers
{
    public class AdminProductController :BaseController
    {
        ProductAdmin AdminOperation;
        NavbarViewModel navbarVM;
        public AdminProductController()
        {
            AdminOperation = new ProductAdmin();
               navbarVM = new NavbarViewModel();
        }
        // GET: Admin/Product
        public ActionResult Index()
        {
            return View();

        }
        public ActionResult AddProduct()
        {
            return PartialView("_addProduct", AdminOperation.GetAddProductView());
        }
        [HttpPost]
        public ActionResult AddProduct(FormCollection fc)
        {
            ProductDTO product = new ProductDTO();


            product.ProductName = fc["name"];
            product.Description = fc["description"];
            product.UnitPrice = Convert.ToDecimal(fc["price"]);
            product.UnitsInStock = Convert.ToByte(fc["stock"]);
            product.IsActive = Convert.ToBoolean(fc["isactive"]);
            if (fc["discount"] == "")
            {
                product.Discount = null;
            }
            else
            {
                product.Discount = Convert.ToDecimal(fc["discount"]);
            }

            SubCategoryDTO sub = new SubCategoryDTO();
            sub.MineID = Convert.ToInt32(fc["mine"]);
            sub.CategoryID = Convert.ToInt32(fc["category"]);
            if (fc["gem"] == "")
            {
                sub.GemID = null;
            }
            else
            {
                sub.GemID = Convert.ToInt32(fc["gem"]);
            }
                        
            return Json(AdminOperation.AddProduct(product,sub), JsonRequestBehavior.AllowGet);
        }

        public ActionResult ProductUpdate(int ProductID)
        {
            return PartialView("_updateProduct", AdminOperation.UpdateProductView(ProductID));
        }
        [HttpPost]
        public ActionResult ProductUpdate(FormCollection fc,int ProductID)
        {
            ProductDTO product = new ProductDTO();
            product.ProductID = ProductID;
            product.ProductName = fc["name"];
            product.Description = fc["description"];
            product.UnitPrice = Convert.ToDecimal(fc["price"]);
            product.UnitsInStock = Convert.ToByte(fc["stock"]);
            product.IsActive = Convert.ToBoolean(fc["isactive"]);
            product.GemWeight =Convert.ToDecimal(fc["weight"]);
            product.UnitsInStock = Convert.ToByte(fc["stock"]);
            if (fc["discount"] == "")
            {
                product.Discount = null;
            }
            else
            {
                product.Discount = Convert.ToDecimal(fc["discount"]);
            }

            SubCategoryDTO sub = new SubCategoryDTO();
            sub.MineID = Convert.ToInt32(fc["mine"]);
            sub.CategoryID = Convert.ToInt32(fc["category"]);
            if (fc["gem"] == "")
            {
                sub.GemID = null;
            }
            else
            {
                sub.GemID = Convert.ToInt32(fc["gem"]);
            }

            return Json(AdminOperation.UpdateProduct(product, sub), JsonRequestBehavior.AllowGet);
        }

    }
}