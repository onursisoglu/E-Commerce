using Jewelery.BLL.Extensions;
using Jewelery.BLL.Service;
using Jewelry.DTO.Model.DTO;
using Jewelry.DTO.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelery.BLL.BO
{
   public class Home
    {
        EntityService service = new EntityService();
        CategoryDTO ctgrydto = new CategoryDTO();

        public NavbarViewModel Categories()
        {
            NavbarViewModel vm = new NavbarViewModel();
            

            vm.CategoryList = service.CategoryService.GetByCondition(x=>x.IsActive==true).Select(x => x.MapTO<CategoryDTO>()).ToList();
            vm.MineList = service.MineService.GetByCondition(x => x.IsActive == true).Select(x => x.MapTO<MineDTO>()).ToList();
          
            vm.SubCategoryList = service.SubCategoryService.GetByCondition(x => x.IsActive == true).Select(c => c.MapTO<SubCategoryDTO>()).ToList();
            foreach (var item in vm.SubCategoryList)
            {
                item.MineDTO = service.MineService.Detail(item.MineID).MapTO<MineDTO>();
                if (item.GemID.HasValue)
                {
                    item.GemDTO = service.GemService.Detail(item.GemID.Value).MapTO<GemDTO>();
                }

                item.CategoryDTO = service.CategoryService.Detail(item.CategoryID).MapTO<CategoryDTO>();
            }


            return vm;
        }
        public ProductsViewModel OpportunityProducts()
        {
            ProductsViewModel vm = new ProductsViewModel();
            vm.EnCokSatilanlar= service.ProductService.GetByCondition(c => c.OrderDetails.Sum(x => x.Quantity.Value) > 0).Take(5).OrderByDescending(c => 
c.OrderDetails.Sum(a => a.Quantity.Value)).Select(a=>a.MapTO<ProductDTO>()).ToList();

            vm.EnSonSatinAlinanlar = service.OrderDetailService.GetByCondition(x=>x.IsActive==true).OrderByDescending(c=>c.AddedDate).Select(a=>a.MapTO<OrderDetailDTO>()).Take(5).ToList();
            foreach (var item in vm.EnSonSatinAlinanlar)
            {
                item.ProductPhoto = service.ProductService.Detail(item.ProductID).ProductPhoto;
                item.ProductName = service.ProductService.Detail(item.ProductID).ProductName;
                item.Discount= service.ProductService.Detail(item.ProductID).Discount;

            }
            vm.indirimdeOlanlar = service.ProductService.GetByCondition(c => c.Discount != null).OrderByDescending(x => x.AddedDate).Select(a=>a.MapTO<ProductDTO>()).Take(5).ToList();
            return vm;
        }
    }
}
