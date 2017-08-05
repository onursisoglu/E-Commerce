using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jewelery.WebUI.Controllers
{

    using BLL.BO;
    using Jewelry.DTO.Model.DTO;

    public class LoginController : Controller
    {
        LoginOperation loginOperation;
        public LoginController()
        {
            loginOperation = new LoginOperation();
        }
        // GET: Login
        public ActionResult Index()
        {


            return View();
        }
        [HttpPost]
        public ActionResult Index(CustomerDTO customer)
        {
            if (ModelState.IsValid)
            {
                if (loginOperation.SignUp(customer)==false)
                {   
                    ViewData["sameEmailError"] = "Sistemde bu email adresine sahip bir kayıt vardır.";
                    return View();
                }
                else
                {
                    Session["Customer"] = customer;
                    return RedirectToAction("Index","Home");
                }
            }

            else
            {
                return Redirect("/");
            }
            
        }
        [HttpPost]
        public ActionResult SignIn(FormCollection fc)
        {
            string email = fc["email"];
            string password = fc["password"];

            
            if (loginOperation.SigninIndex(email,password) == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                Session["Customer"] = loginOperation.SigninIndex(email,password);
                CustomerDTO customer = Session["Customer"] as CustomerDTO;
                
                if (Session["Products"] != null)
                {
                    List<ShoppingCartDTO> _productList = Session["Products"] as List<ShoppingCartDTO>;
                    foreach (var item in _productList)
                    {
                        item.CustomerID = customer.CustomerID;
                    }


                }

            }



            return RedirectToAction("Index", "Home");
        }

        public ActionResult LogOut()
        {
            Session["Customer"] = null;
            return Redirect("/");
        }


    }
}