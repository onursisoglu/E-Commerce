using Jewelery.BLL.BO;
using Jewelry.DTO.Model.DTO;
using Jewelry.DTO.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jewelery.WebUI.Controllers
{

    public class ShoppingController : BaseController
    {
        ShoppingOperation shopping;
        public ShoppingController()
        {
            shopping = new ShoppingOperation();
        }
        // GET: Shopping
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult Index2()
        {
            List<ShoppingCartDTO> productList = Session["Products"] as List<ShoppingCartDTO>;
            return PartialView("_customerShoppingCart", productList);
        }

        public ActionResult AddShoppingCart(int ProductID, int? CustomerID)
        {
             List<ShoppingCartDTO> yenisepet = new List<ShoppingCartDTO>();
            List<ShoppingCartDTO> sepet = Session["Products"] as List<ShoppingCartDTO>;
            yenisepet = shopping.ShopBasket(ref sepet, ProductID, CustomerID);
            Session["Products"] = yenisepet;
            return Json(yenisepet, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteBag(int ProductID)
        {
            List<ShoppingCartDTO> productList = Session["Products"] as List<ShoppingCartDTO>;

            ShoppingCartDTO product = productList.FirstOrDefault(c => c.ProductID == ProductID);
            productList.Remove(product);
            Session["Products"] = productList;

            return Json(productList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AdetGuncelleme(short txtAdet, int ProductID)
        {
            List<ShoppingCartDTO> shp = Session["Products"] as List<ShoppingCartDTO>;
            ShoppingCartDTO nQuantity = shp.FirstOrDefault(c => c.ProductID == ProductID);
            nQuantity.Quantity = txtAdet;
            Session["Products"] = shp;
            return Json(shp, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Payment()
        {
            if (Session["Customer"]==null)
            {
                return RedirectToAction("Index", "Login");
            }
            if (Session["Products"]==null)
            {
                return RedirectToAction("Index", "Home");
            }
            CustomerDTO customer = Session["Customer"] as CustomerDTO;
            
            return View(customer);
        }

        [HttpPost]
        public ActionResult Payment(FormCollection fc)
        {
            string message="";
            CustomerDTO customer = Session["Customer"] as CustomerDTO;
            OrderDTO order = new OrderDTO();
            order.CustomerID = customer.CustomerID;
            order.AddressID =Convert.ToInt32(fc["adresID"]);
            order.OrderDate = DateTime.Now;
            order.ShippedDate = order.OrderDate.Value.AddDays(5);
            List<ShoppingCartDTO> bag = Session["Products"] as List<ShoppingCartDTO>;
            
            if (shopping.Pay(order,bag) == true)
            {
                Session["Products"] = null;
                message= "Siparişiniz başarılıdır. Ürünleriniz " + order.ShippedDate.Value.AddDays(10) + " Tarihine kadar gönderilecektir";
            }
            return View("PayResult",message);
        }


    }
}