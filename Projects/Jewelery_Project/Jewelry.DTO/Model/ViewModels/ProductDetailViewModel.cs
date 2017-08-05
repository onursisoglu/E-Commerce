using Jewelery.DAL.Entity;
using Jewelry.DTO.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelry.DTO.Model.ViewModels
{
   public class ProductDetailViewModel
    {
        public ProductDTO Product { get; set; }
        public List<CommentDTO> Comments { get; set; }
        public CommentDTO Yorum { get; set; }
        public FavoriteProductDTO Favourites { get; set; }
        public List<ProductDTO> ProductList { get; set; }
        public List<CategoryDTO> CategoryDTO { get; set; }
        public List<SubCategoryDTO> SubCategoryDTO { get; set; }
    }
}
