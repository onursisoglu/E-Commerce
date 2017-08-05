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

namespace Jewelery.BLL.BO
{
    public class ProductOperation
    {
        EntityService service = new EntityService();
        ProductDetailViewModel productVM = new ProductDetailViewModel();

        public ProductDetailViewModel CategoryProducts(int? id, string sort)
        {

            if (sort == "asc")
            {
                productVM.ProductList = service.ProductService.GetByCondition(c => c.SubCategoryID == id.Value).OrderBy(x => x.UnitPrice).Select(x => x.MapTO<ProductDTO>()).ToList();
                return productVM;
            }
            else if (sort == "desc")
            {
                productVM.ProductList = service.ProductService.GetByCondition(c => c.SubCategoryID == id.Value).OrderByDescending(x => x.UnitPrice).Select(x => x.MapTO<ProductDTO>()).ToList();
                return productVM;
            }
            productVM.ProductList = service.ProductService.GetAll().Where(c => c.SubCategoryID == id.Value).Select(x => x.MapTO<ProductDTO>()).ToList();

            productVM.CategoryDTO = service.CategoryService.GetAll().Select(x => x.MapTO<CategoryDTO>()).ToList();
            productVM.SubCategoryDTO = service.SubCategoryService.GetAll().Select(c => c.MapTO<SubCategoryDTO>()).ToList();
            foreach (var item in productVM.SubCategoryDTO)
            {
                item.MineDTO = service.MineService.Detail(item.MineID).MapTO<MineDTO>();
                if (item.GemID.HasValue)
                {
                    item.GemDTO = service.GemService.Detail(item.GemID.Value).MapTO<GemDTO>();
                }

                item.CategoryDTO = service.CategoryService.Detail(item.CategoryID).MapTO<CategoryDTO>();
            }
            productVM.Product = new ProductDTO();
            productVM.Product.SubCategoryID = id.Value;
            return productVM;

        }

        public ProductDetailViewModel ProductDetail(int id, int SubCategoryID)
        {
            Product prdct = service.ProductService.Detail(id);
            if (prdct!=null)
            {
                productVM.Product = prdct.MapTO<ProductDTO>();
                productVM.Product.ProductPicturesDTO = prdct.ProductPictures.Select(x => x.MapTO<ProductPictureDTO>()).ToList();

                productVM.Product.SubCategoryDTO = prdct.SubCategory.MapTO<SubCategoryDTO>();
                if (prdct.SubCategory.GemID != null)
                {
                    productVM.Product.SubCategoryDTO.GemDTO = prdct.SubCategory.Gem.MapTO<GemDTO>();
                }
                else
                {
                    productVM.Product.SubCategoryDTO.GemDTO = null;
                }
                
                productVM.ProductList = service.ProductService.GetByCondition(x => x.SubCategoryID == SubCategoryID && x.ProductID != id).Select(x => x.MapTO<ProductDTO>()).ToList();
                foreach (var product in productVM.ProductList)
                {
                    product.ProductPicturesDTO = service.ProductPictureService.GetByCondition(x => x.ProductID == product.ProductID).Select(c => c.MapTO<ProductPictureDTO>()).ToList();
                }
                 
                productVM.Comments = prdct.Comments.OrderByDescending(x => x.AddedDate).Select(c => c.MapTO<CommentDTO>()).ToList();
                foreach (var item in productVM.Comments)
                {
                    item.CustomerDTO = service.CustomerService.Detail(item.CustomerID).MapTO<CustomerDTO>();
                }
            }
            
            return productVM;
        }

        public CommentDTO CommentPost(CommentDTO comment)
        {
            Comment postComment = comment.MapTO<Comment>();

            comment.CustomerDTO = service.CustomerService.Detail(postComment.CustomerID).MapTO<CustomerDTO>();

            if (service.CommentService.Add(postComment)==1)
            {
                
                return comment;
            }
            else
            {
                return null;
            }

        }

        public FavoriteProductDTO FavouritePost(int ProductID,int CustomerID)
        {
            FavoriteProductDTO favoriteDTO = service.FavouriteProductService.AddFavourite(CustomerID, ProductID).MapTO<FavoriteProductDTO>() ;
            Customer cust = service.CustomerService.Detail(CustomerID);
            favoriteDTO.CustomerDTO = cust.MapTO<CustomerDTO>();
            favoriteDTO.CustomerDTO.FavoriteProductsDTO = cust.FavoriteProducts.Select(x => x.MapTO<FavoriteProductDTO>()).ToList();
            //foreach (var item in favoriteDTO.CustomerDTO.FavoriteProductsDTO)
            //{
            //    item.ProductDTO = service.ProductService.Detail(item.ProductID).MapTO<ProductDTO>();
            //    item.ProductDTO.ProductPicturesDTO = service.ProductPictureService.GetByCondition(x => x.ProductID == item.ProductID).Take(1).Select(c => c.MapTO<ProductPictureDTO>()).ToList();
            //} 
            favoriteDTO.CustomerDTO.AddressesDTO= service.AddressService.GetByCondition(x => x.CustomerID == CustomerID && x.IsActive == true).Select(c => c.MapTO<AddressDTO>()).ToList();
            return favoriteDTO;
        }

        public List<ProductDTO> SearchInputResult(string q)
        {
            List<ProductDTO> product = service.ProductService.GetByCondition(c => c.IsActive == true && c.ProductName.Contains(q)).Select(c => new ProductDTO
            {
                ProductID = c.ProductID,
                ProductName = c.ProductName,
            }).ToList();
            return product;
        }

    }
}
