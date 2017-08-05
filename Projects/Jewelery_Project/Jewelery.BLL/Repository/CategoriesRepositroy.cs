using Jewelery.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Jewelery.BLL.Repository
{
    public class CategoryRepositroy : BaseRepository,IRepository<Category>
    {
        public Category Detail(int id)
        {

            Category kategori = db.Categories.Find(id);
            return kategori;
        }

        public int Add(Category deger)
        {
            deger.IsActive = true;
            deger.AddedDate = DateTime.Now;
            db.Categories.Add(deger);
            return db.SaveChanges();
        }

        public int Update(Category deger)
        {
            Category ctgry = Detail(deger.CategoryID);
            ctgry = deger;
            ctgry.UpdateDate = DateTime.Now;
            return db.SaveChanges();
        }

        public List<Category> GetAll()
        {
            List<Category> katList= db.Categories.ToList();
            return katList;
        }

        public int Delete(int id)
        {
            
            Category ctgry = Detail(id);
            if (ctgry!=null)
            {
                ctgry.IsActive = false;
                ctgry.DeletedDate = DateTime.Now;
                return db.SaveChanges();
            }
            return 0; 
        }

        public List<Category> GetByCondition(Expression<Func<Category, bool>> lambda)
        {
            return db.Categories.Where(x => x.IsActive == true).Where(lambda).ToList();
        }
        public Category GetByFind(Expression<Func<Category, bool>> lambda)
        {
            return db.Categories.FirstOrDefault(lambda);

        }
    }
}
