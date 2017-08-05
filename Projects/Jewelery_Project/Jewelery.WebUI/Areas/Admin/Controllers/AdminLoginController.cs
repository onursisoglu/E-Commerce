using Jewelery.BLL.BO.Admin;
using Jewelry.DTO.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jewelery.WebUI.Areas.Admin.Controllers
{
    
    public class AdminLoginController : Controller
    {
        HomeAdmin adminOperation;
        // GET: Admin/Login
        public AdminLoginController()
        {
            adminOperation = new HomeAdmin();
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection fc)
        {
            string email = fc["Email"];
            string password = fc["Password"];
            CustomerDTO user = adminOperation.AdminLogin(email, password);
            if (user!=null&&user.Role==true)
            {
                Session["Admin"] = user;
                return RedirectToAction("Index", "AdminHome");
              
            }
            else
            {
                ViewData["Message"] = "Admin Girişi İçin Bilgiler Doğru Değil veya Yetkiniz Bulunmuyor";
                return View();
            }
            
        }
        public ActionResult LogOut()
        {
            Session["Admin"] = null;
            return Redirect("/");
        }
    }
}