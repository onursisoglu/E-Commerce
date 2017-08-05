using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Jewelery.DAL.Entity;
namespace Jewelery.BLL.Repository
{
    public class OrderRepository : BaseRepository,IRepository<Order>
    {
        public int Add(Order deger)
        {
            deger.IsActive = true;
            deger.AddedDate = DateTime.Now;
            db.Orders.Add(deger);
            return db.SaveChanges();
        }

        public int Delete(int id)
        {
            Order order = Detail(id);
            if (order != null)
            {
                order.IsActive = false;
                order.DeletedDate = DateTime.Now;
                return db.SaveChanges();
            }
            return 0;
        }

        public Order Detail(int id)
        {
            Order Order = db.Orders.Find(id);
            return Order;
        }

        public List<Order> GetAll()
        {
            List<Order> OrderList = db.Orders.ToList();
            return OrderList;
        }

        public List<Order> GetByCondition(Expression<Func<Order, bool>> lambda)
        {
            return db.Orders.Where(x => x.IsActive == true).Where(lambda).ToList();
        }

        public Order GetByFind(Expression<Func<Order, bool>> lambda)
        {
            return db.Orders.FirstOrDefault(lambda);
        }

        public int Update(Order deger)
        {
            Order Order = Detail(deger.OrderID);
            Order = deger;
            Order.UpdateDate = DateTime.Now;
            return db.SaveChanges();
        }
    }
    }

