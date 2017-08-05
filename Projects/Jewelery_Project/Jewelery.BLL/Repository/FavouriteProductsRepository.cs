using Jewelery.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Jewelery.BLL.Repository
{
   public class FavouriteProductsRepository:BaseRepository
    {

        public FavoriteProduct AddFavourite(int CustomerID, int ProductID)
        {
            FavoriteProduct Product = db.FavoriteProducts.FirstOrDefault(c => c.ProductID == ProductID && c.CustomerID == CustomerID);
            if (Product == null)
            {
                Product = new FavoriteProduct();
                Product.CustomerID = CustomerID;
                Product.ProductID = ProductID;
                Product.IsActive = true;

                db.FavoriteProducts.Add(Product);
                db.SaveChanges();
                return Product;

            }
            else
            {
                if (Product.IsActive == true)
                {

                    Product.IsActive = false;
                    
                    db.SaveChanges();
                    return Product;
                }
                else
                {
                    Product.IsActive = true;
                   
                    db.SaveChanges();
                    return Product;
                }
            }
           
        }


        public List<FavoriteProduct> CustomerFavouriteProducts(int CustomerID)
        {
            List<FavoriteProduct> CustomerFavourite = db.FavoriteProducts.Where(x => x.CustomerID == CustomerID).ToList();
            return CustomerFavourite;
        }
    }
}
