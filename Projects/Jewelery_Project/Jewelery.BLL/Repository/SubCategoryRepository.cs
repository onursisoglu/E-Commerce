using Jewelery.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Jewelery.BLL.Repository
{
    public class SubCategoryRepository : BaseRepository, IRepository<SubCategory>
    {
        public int Add(SubCategory deger)
        {

            deger.IsActive = true;
            db.SubCategories.Add(deger);
            return db.SaveChanges();
        }

        public int Delete(int id)
        {
            SubCategory subCat = Detail(id);
            if (subCat != null)
            {
                subCat.IsActive = false;
                return db.SaveChanges();
            }
            return 0;
        }

        public SubCategory Detail(int id)
        {
            SubCategory subCat = db.SubCategories.Find(id);
            return subCat;
        }

        public List<SubCategory> GetAll()
        {
            List<SubCategory> SubCategoryList = db.SubCategories.ToList();
            return SubCategoryList;
        }

        public List<SubCategory> GetByCondition(Expression<Func<SubCategory, bool>> lambda)
        {
            return db.SubCategories.Where(lambda).ToList();
        }

        public SubCategory GetByFind(Expression<Func<SubCategory, bool>> lambda)
        {
                return db.SubCategories.FirstOrDefault(lambda);
            
        }
        public int Update(SubCategory deger)
        {
            SubCategory subCat = Detail(deger.SubCategoryID);
            subCat = deger;
            return db.SaveChanges();
        }
    }
}
