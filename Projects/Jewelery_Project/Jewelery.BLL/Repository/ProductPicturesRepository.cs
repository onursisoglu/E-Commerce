using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Jewelery.DAL.Entity;
namespace Jewelery.BLL.Repository
{
    public class ProductPicturesRepository :BaseRepository,IRepository<ProductPicture>
    {
        public int Add(ProductPicture deger)
        {
            deger.IsActive = true;
            deger.AddedDate = DateTime.Now;
            db.ProductPictures.Add(deger);
            return db.SaveChanges();
        }

        public int Delete(int id)
        {
            ProductPicture ProductPicture = Detail(id);
            if (ProductPicture != null)
            {
                ProductPicture.IsActive = false;
                ProductPicture.DeletedDate = DateTime.Now;
                return db.SaveChanges();
            }
            return 0;
        }

        public ProductPicture Detail(int id)
        {
            ProductPicture ProductPicture = db.ProductPictures.Find(id);
            return ProductPicture;
        }

        public List<ProductPicture> GetAll()
        {
            List<ProductPicture> ProductPicture = db.ProductPictures.ToList();
            return ProductPicture;
        }

        public List<ProductPicture> GetByCondition(Expression<Func<ProductPicture, bool>> lambda)
        {
            return db.ProductPictures.Where(x => x.IsActive == true).Where(lambda).ToList();
        }

        public ProductPicture GetByFind(Expression<Func<ProductPicture, bool>> lambda)
        {
            return db.ProductPictures.FirstOrDefault(lambda);
        }

        public int Update(ProductPicture deger)
        {
            ProductPicture ProductPicture = Detail(deger.ID);
            ProductPicture = deger;
            ProductPicture.UpdateDate = DateTime.Now;
            return db.SaveChanges();
        }
    }
}
