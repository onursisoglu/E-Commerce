using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Jewelery.DAL.Entity;
namespace Jewelery.BLL.Repository
{
    public class ProductsRepository : BaseRepository, IRepository<Product>
    {
        public int Add(Product deger)
        {
            deger.IsActive = true;
            deger.AddedDate = DateTime.Now;
            db.Products.Add(deger);
            return db.SaveChanges();
        }

        public int Delete(int id)
        {
            Product _product = Detail(id);
            if (_product != null)
            {
                _product.IsActive = false;
                _product.DeletedDate = DateTime.Now;
                return db.SaveChanges();
            }
            return 0;
        }

        public Product Detail(int id)
        {
            Product _product = db.Products.Find(id);
            return _product;
        }

        public List<Product> GetAll()
        {
            List<Product> _product = db.Products.ToList();
            return _product;
        }

        public int Update(Product deger)
        {
            Product _product = Detail(deger.ProductID);
            _product = deger;
            _product.UpdateDate = DateTime.Now;
            return db.SaveChanges();
        }

        //public List<Product> Similarproducts(int? id,Expression<Func<Product, bool>> lambda)
        //{
        //    List<Product> productList = db.Products.Where(c => c.SubCategoryID == id).ToList();

        //    return productList;
        //}

        public List<Product> GetByCondition(Expression<Func<Product, bool>> lambda)
        {
            return db.Products.Where(x => x.IsActive == true).Where(lambda).ToList();
        }
       
        public Product GetByFind(Expression<Func<Product, bool>> lambda)
        {
            return db.Products.FirstOrDefault(lambda);
        }
    }
}
