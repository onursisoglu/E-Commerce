using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Jewelery.DAL.Entity;
namespace Jewelery.BLL.Repository
{
    public class OrderDetailRepository : BaseRepository,IRepository<OrderDetail>
    {
        public int Add(OrderDetail deger)
        {
            deger.IsActive = true;
            deger.AddedDate = DateTime.Now;
            db.OrderDetails.Add(deger);
            return db.SaveChanges();
        }

        public int Delete(int id)
        {
            OrderDetail detail = Detail(id);
            if (detail != null)
            {
                detail.IsActive = false;
                detail.DeletedDate = DateTime.Now;
                return db.SaveChanges();
            }
            return 0;
        }

        public OrderDetail Detail(int id)
        {
            OrderDetail od = db.OrderDetails.Find(id);
            return od;
        }

        public List<OrderDetail> GetAll()
        {
            List<OrderDetail> od = db.OrderDetails.ToList();
            return od;
        }

        public List<OrderDetail> GetByCondition(Expression<Func<OrderDetail, bool>> lambda)
        {
            return db.OrderDetails.Where(x => x.IsActive == true).Where(lambda).ToList();
        }

        public OrderDetail GetByFind(Expression<Func<OrderDetail, bool>> lambda)
        {
            return db.OrderDetails.FirstOrDefault(lambda);
        }

        public int Update(OrderDetail deger)
        {
            OrderDetail od = Detail(deger.ID);
            od = deger;
            od.UpdateDate = DateTime.Now;
            return db.SaveChanges();
        }
    }
}
