using Jewelery.BLL.BO;
using Jewelry.DTO.Model.DTO;
using Jewelry.DTO.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Jewelery.WebUI.Controllers
{


    public class ProductController : BaseController
    {

        ProductDetailViewModel dm;
        ProductOperation po;
        public ProductController()
        {

            dm = new ProductDetailViewModel();
            po = new ProductOperation();
        }
        // GET: Product
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult CategoryProduct(int? id, string sort)
        {
            if (id.HasValue)
            {
                if (sort != null)
                {
                    return PartialView("SortBy", po.CategoryProducts(id.Value, sort));
                }

                else
                {
                    return View("Index", po.CategoryProducts(id.Value, sort));
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }
        public ActionResult ProductDetail(int id, int? subcategoryID)
        {
            if (subcategoryID == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(po.ProductDetail(id, subcategoryID.Value));

        }

        // Arama inputu
        public JsonResult Searchleer(string q)
        {
            //List<ProductDTO> product = service.ProductService.GetByCondition(c => c.IsActive == true && c.ProductName.Contains(q)).Select(c => new ProductDTO
            //{
            //    ProductID = c.ProductID,
            //    ProductName = c.ProductName,



            //}).ToList();
            return Json(po.SearchInputResult(q), JsonRequestBehavior.AllowGet);
        }

        // Yorum Ekle

        [HttpPost]
        public ActionResult PostComment(int pID, int? cID, string text)
        {
            if (cID == null)
            {
                return Json(new { url = Url.Action("Index", "Login") });
            }
            else
            {
                dm.Yorum = new CommentDTO();
                dm.Yorum.ProductID = pID;
                dm.Yorum.CustomerID = Convert.ToInt32(cID.Value);
                dm.Yorum.Content = text;
                dm.Yorum.AddedDate = DateTime.Now;
                dm.Yorum.IsActive = true;
                CommentDTO result = po.CommentPost(dm.Yorum);
                if (result != null)
                {
                    return PartialView("_comment", dm);
                }
                else
                {
                    return Json(new { span = "Sistemde bu email adresine sahip bir kayıt vardır." });
                }



            }
        }

        // Favori Ürünlere Ekle ** 
        [HttpPost]
        public ActionResult FavProduct(int ProductID, int? CustomerID)
        {
            var a = po.FavouritePost(ProductID, CustomerID.Value);
            Session["Customer"] = a.CustomerDTO;
            return Json(a, JsonRequestBehavior.AllowGet);
        }

        //public ActionResult ProductTable()
        //{
        //    ProductsViewModel vm = new ProductsViewModel();

        //    vm.EnCokSatilanlar = db.Products.Where(c => c.OrderDetails.Sum(x => x.Quantity.Value) > 0).Take(5).OrderByDescending(c => c.OrderDetails.Sum(a => a.Quantity.Value)).ToList();
        //    vm.EnSonSatinAlinanlar = db.OrderDetails.OrderByDescending(c => c.AddedDate).Take(5).ToList();



        //    return PartialView("_productTable", vm);



        //}
    }
    
}