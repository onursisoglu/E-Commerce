using Jewelery.BLL.Service;
using Jewelery.DAL.Entity;
using Jewelery.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Jewelery.WebApi.Controllers
{
    public class DefaultController : ApiController
    {
        EntityService service = new EntityService();

        [HttpGet]
        public IHttpActionResult CategoryReport()
        {
            List<CategoryChart> chartList = new List<CategoryChart>();
            int? toplamSatislar = service.OrderDetailService.GetAll().Sum(x => x.Quantity);
            

            List<Category> categoryList = service.CategoryService.GetAll();
            foreach (var item in categoryList)
            {
                int? kategoriSatislari = service.OrderDetailService.GetAll().Where(x => x.Product.SubCategory.CategoryID == item.CategoryID).Sum(c=>c.Quantity);
                int? oran = (kategoriSatislari * 100) / toplamSatislar;
                chartList.Add(new CategoryChart { CategoryName = item.CategoryName, Persentage = oran.Value });
            }


                return Json(chartList);
        }
        [HttpGet]
        public IHttpActionResult ProductReport()
        {

            List<ProductChart> prodcutChart = new List<ProductChart>();
            int?toplamSatislar= service.OrderDetailService.GetAll().Sum(x => x.Quantity);
            List<OrderDetail> productlist = service.OrderDetailService.GetByCondition(x => x.ProductID == x.Product.ProductID).ToList();

            foreach (var item in productlist)
            {
                int? urunSatislari = service.OrderDetailService.GetAll().Where(x => x.ProductID == item.ProductID).Sum(c => c.Quantity);
                int? oran = (urunSatislari * 100) / toplamSatislar;
                prodcutChart.Add(new ProductChart { ProductName = item.Product.ProductName, Persentage = oran.Value,ProductPhoto=item.Product.ProductPhoto });
            }
            return Json(prodcutChart);
        }
    }
}
