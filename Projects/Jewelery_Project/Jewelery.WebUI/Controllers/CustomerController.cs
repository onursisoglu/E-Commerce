using Jewelery.BLL.Extensions;
using Jewelry.DTO.Model.DTO;
using Jewelry.DTO.Model.ViewModels;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using System.Collections.Generic;
using Jewelery.BLL.BO;

namespace Jewelery.WebUI.Controllers
{


    public class CustomerController : Controller
    {

        CustomerDTO Customerdto;
        CustomerInfoViewModel vm;


        CustomerOperation custOperation;

        public CustomerController()
        {
            custOperation = new CustomerOperation();
            Customerdto = new CustomerDTO();
            vm = new CustomerInfoViewModel();
        }

        // GET: Customer
        public ActionResult Index()
        {

            return View();
        }

        // Üye profili Ajax ile gelecek kısımlar
        public ActionResult CustProfile(int CustomerID, string info)
        {


            if (info == "Info")
            {
                return PartialView("_customerDetail", custOperation.CustomerProfile(CustomerID, info));
            }
            else if (info == "Order")
            {
                return PartialView("_customerOrder", custOperation.CustomerProfile(CustomerID, info));
            }
            else if (info == "Adres")
            {
                return PartialView("_customerAddress", custOperation.CustomerProfile(CustomerID, info));
            }
            else if (info=="Pass")
            {
                return PartialView("_resetPassword", custOperation.CustomerProfile(CustomerID, info));
            }
            else if (info== "Favourite")
            {
                return PartialView("_customerFavourites", custOperation.CustomerProfile(CustomerID, info));
            }
            else
            {
                return RedirectToAction("/");
            }
        }

    // Üyelik Bilgisi Güncelle

    [HttpPost]
        public ActionResult InfoPost(FormCollection fc,int CustomerID)
        {

            vm.Customer = new CustomerDTO();
            vm.Customer.Name = fc["Name"];
            vm.Customer.CustomerID = CustomerID;
            vm.Customer.LastName = fc["LastName"];
            vm.Customer.Phone = fc["Phone"];
            vm.Customer.Email = fc["Email"];
            vm.Customer.BirthDate=new DateTime(Convert.ToInt32(fc["Year"]), Convert.ToInt32(fc["Month"]), Convert.ToInt32(fc["Day"]));
            custOperation.CustomerInfoPost(vm.Customer, CustomerID);
            
                return RedirectToAction("Index");
            
        }

        //POST : Reset Password
        [HttpPost]
        public ActionResult ResetPass2(FormCollection fc, int id)
        {
            string password = fc["Customer.Password"];

            custOperation.CustomerResetPassword(password, id);
            
            return RedirectToAction("Index","Customer");
        }

        // Adres Güncelle
        [HttpPost]
        public ActionResult AddressPost(int AddressID,FormCollection fc)
        {
            vm._adres = new AddressDTO();
            vm._adres.AddressID = AddressID;
            vm._adres.City = fc["City"];
            vm._adres.District= fc["District"];
            vm._adres.Country= fc["Country"];
            vm._adres.Address1 = fc["Address1"];
            CustomerDTO customer = Session["Customer"] as CustomerDTO;

            vm._adres.CustomerID = customer.CustomerID;
            custOperation.CustomerEditAddress(vm._adres, AddressID);
            return RedirectToAction("Index","Customer");
        }

        // Adres Ekle
        [HttpPost]
        public ActionResult NewAddress(FormCollection fc,int CustomerID)
        {
            vm._adres = new AddressDTO();
            vm._adres.CustomerID = CustomerID;
            vm._adres.City = fc["City"];
            vm._adres.District = fc["District"];
            vm._adres.Country = fc["Country"];
            vm._adres.Address1 = fc["Address1"];
            custOperation.CustomerNewAddress(vm._adres, CustomerID);

            return RedirectToAction("Index", "Customer");
        }
        public ActionResult AddressDelete(int AddressID)
        {
            return Json(custOperation.CustomerAddressDelete(AddressID));
        }
    }
}