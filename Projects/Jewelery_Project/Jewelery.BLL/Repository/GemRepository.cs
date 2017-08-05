using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Jewelery.DAL.Entity;
namespace Jewelery.BLL.Repository
{
    public class GemRepository : BaseRepository,IRepository<Gem>
    {
        public int Add(Gem deger)
        {
            deger.IsActive = true;
            deger.AddedDate = DateTime.Now;
            db.Gems.Add(deger);
            return db.SaveChanges();
        }

        public int Delete(int id)
        {
            Gem _gem = Detail(id);
            if (_gem != null)
            {
                _gem.IsActive = false;
                _gem.DeletedDate = DateTime.Now;
                return db.SaveChanges();
            }
            return 0;
        }

        public Gem Detail(int id)
        {
            Gem _gem = db.Gems.Find(id);
            return _gem;
        }

        public List<Gem> GetAll()
        {
            List<Gem> _gemList = db.Gems.ToList();
            return _gemList;
        }

        public List<Gem> GetByCondition(Expression<Func<Gem, bool>> lambda)
        {
            return db.Gems.Where(x => x.IsActive == true).Where(lambda).ToList();
        }

        public Gem GetByFind(Expression<Func<Gem, bool>> lambda)
        {
            return db.Gems.FirstOrDefault(lambda);
        }

        public int Update(Gem deger)
        {
            Gem _gem = Detail(deger.GemID);
            _gem = deger;
            _gem.UpdateDate = DateTime.Now;
            return db.SaveChanges();
        }
    }
}
