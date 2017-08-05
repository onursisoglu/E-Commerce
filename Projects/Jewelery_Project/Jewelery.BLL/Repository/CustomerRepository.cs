using Jewelery.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Jewelery.BLL.Repository
{
    public class CustomerRepository :BaseRepository,IRepository<Customer>
    {
        public int Add(Customer deger)
        {
            deger.IsActive = true;
            deger.AddedDate = DateTime.Now;
            db.Customers.Add(deger);
            return Save();
        }

        public int Delete(int id)
        {
            Customer _customer = Detail(id);
            if (_customer != null)
            {
                _customer.IsActive = false;
                _customer.DeletedDate = DateTime.Now;
                return db.SaveChanges();
            }
            return 0;
        }

        public Customer Detail(int id)
        {
            Customer _customer = db.Customers.Find(id);
            return _customer;
        }

        public List<Customer> GetAll()
        {
            List<Customer> CustomerList = db.Customers.ToList();
            return CustomerList;
        }

        public int Update(Customer deger)
        {
            Customer _customer = Detail(deger.CustomerID);
            _customer = deger;
            _customer.UpdateDate = DateTime.Now;
            return db.SaveChanges();
        }
        public List<Customer> GetByCondition(Expression<Func<Customer, bool>> lambda)
        {
            return db.Customers.Where(x => x.IsActive == true).Where(lambda).ToList();
        }
        public Customer GetByFind(Expression<Func<Customer, bool>> lambda)
        {
            return db.Customers.FirstOrDefault(lambda);

        }

        public bool CheckEmail(string email)
        {
            return db.Customers.Any(x => x.Email == email);
        }
    }
}
