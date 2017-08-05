using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Jewelery.DAL.Entity;
namespace Jewelery.BLL.Repository
{
    public class MineRepository : BaseRepository, IRepository<Mine>
    {
        public int Add(Mine deger)
        {
            deger.IsActive = true;
            deger.AddedDate = DateTime.Now;
            db.Mine.Add(deger);
            return db.SaveChanges();
        }

        public int Delete(int id)
        {
            Mine _mine = Detail(id);
            if (_mine != null)
            {
                _mine.IsActive = false;
                _mine.DeletedDate = DateTime.Now;
                return db.SaveChanges();
            }
            return 0;
        }

        public Mine Detail(int id)
        {
            Mine _mine = db.Mine.Find(id);
            return _mine;
        }

        public List<Mine> GetAll()
        {
            List<Mine> _mine = db.Mine.ToList();
            return _mine;
        }

        public List<Mine> GetByCondition(Expression<Func<Mine, bool>> lambda)
        {
            return db.Mine.Where(x => x.IsActive == true).Where(lambda).ToList();
        }

        public Mine GetByFind(Expression<Func<Mine, bool>> lambda)
        {
            return db.Mine.FirstOrDefault(lambda);
        }

        public int Update(Mine deger)
        {
            Mine _mine = Detail(deger.MineID);
            _mine = deger;
            _mine.UpdateDate = DateTime.Now;
            return db.SaveChanges();
        }
    }
}
