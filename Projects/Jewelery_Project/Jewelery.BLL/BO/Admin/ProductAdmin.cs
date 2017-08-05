using Jewelery.BLL.Extensions;
using Jewelery.BLL.Service;
using Jewelery.DAL.Entity;
using Jewelry.DTO.Model.DTO;
using Jewelry.DTO.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelery.BLL.BO.Admin
{
  public  class ProductAdmin
    {
        EntityService service;
        NavbarViewModel navbarVM;
        public ProductAdmin()
        {
            service = new EntityService();
            navbarVM = new NavbarViewModel();
        }
        public NavbarViewModel GetAddProductView()
        {
            navbarVM.CategoryList = service.CategoryService.GetAll().Select(x => x.MapTO<CategoryDTO>()).ToList();
            navbarVM.MineList = service.MineService.GetAll().Select(x => x.MapTO<MineDTO>()).ToList();
            navbarVM.GemList = service.GemService.GetAll().Select(x => x.MapTO<GemDTO>()).ToList();
            return navbarVM;
        }

        public bool AddProduct(ProductDTO product,SubCategoryDTO sub)
        {
            SubCategory subcat = service.SubCategoryService.GetByFind(x => x.CategoryID == sub.CategoryID && x.MineID == sub.MineID && x.GemID.Value == sub.GemID.Value);
            if (subcat != null)
            {
                product.SubCategoryID = subcat.SubCategoryID;
            }
            else
            {
                 subcat = new SubCategory();
                subcat.CategoryID = sub.CategoryID;
                subcat.MineID = sub.MineID;
                subcat.GemID = sub.GemID;
                service.SubCategoryService.Add(subcat);
                if (subcat.SubCategoryID!=null)
                {
                    product.SubCategoryID = subcat.SubCategoryID;
                }
                
            }
            try
            {
                service.ProductService.Add(product.MapTO<Product>());
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            
        }

        public NavbarViewModel UpdateProductView(int ProductID)
        {
            Product _product = service.ProductService.Detail(ProductID);
           
            if (_product!=null)
            {
                navbarVM.Product = _product.MapTO<ProductDTO>();

                navbarVM.Product.SubCategoryDTO = _product.SubCategory.MapTO<SubCategoryDTO>();
                navbarVM.CategoryList = service.CategoryService.GetAll().Select(x => x.MapTO<CategoryDTO>()).ToList();
                navbarVM.MineList = service.MineService.GetAll().Select(x => x.MapTO<MineDTO>()).ToList();
                navbarVM.GemList = service.GemService.GetAll().Select(x => x.MapTO<GemDTO>()).ToList();
                //ProductDTO updateProduct = _product.MapTO<ProductDTO>();
                return navbarVM;
            }
            else
            {
                return null;
            }

        }
        public bool UpdateProduct(ProductDTO data,SubCategoryDTO sub)
        {
            Product product = service.ProductService.Detail(data.ProductID);
            if (product!=null)
            {
                product.ProductName = data.ProductName;
                product.Description = data.Description;
                product.UnitPrice = data.UnitPrice.Value;
                product.UnitsInStock = data.UnitsInStock.Value;
                product.IsActive = data.IsActive;
                product.Discount = data.Discount.Value;
                SubCategory subCategory = service.SubCategoryService.GetByFind(x => x.CategoryID == sub.CategoryID && x.MineID == sub.MineID && x.GemID == sub.GemID);
                if (subCategory!=null)
                {
                    product.SubCategoryID = subCategory.SubCategoryID;
                }
                else
                {
                     subCategory = new SubCategory();

                    subCategory.CategoryID = sub.CategoryID;
                    subCategory.MineID = sub.MineID;
                    subCategory.GemID = sub.GemID;
                    service.SubCategoryService.Add(subCategory);
                    if (subCategory.SubCategoryID != null)
                    {
                        product.SubCategoryID = subCategory.SubCategoryID;
                    }
                }
                
                    service.ProductService.Update(product);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
