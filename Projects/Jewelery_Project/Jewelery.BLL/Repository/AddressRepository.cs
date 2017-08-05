using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Jewelery.DAL.Entity;

namespace Jewelery.BLL.Repository
{
    public class AddressRepository : BaseRepository, IRepository<Address>
    {
        public int Add(Address deger)
        {

            deger.IsActive = true;
            deger.AddedDate = DateTime.Now;
            db.Addresses.Add(deger);
            return db.SaveChanges();
        }

        public int Delete(int id)
        {
            Address _address = Detail(id);
            if (_address != null)
            {
                _address.IsActive = false;
                _address.DeletedDate = DateTime.Now;
                return db.SaveChanges();
            }
            return 0;
        }

        public Address Detail(int id)
        {
            Address _address = db.Addresses.Find(id);
            return _address;
        }

        public List<Address> GetAll()
        {
            List<Address> AddressList = db.Addresses.ToList();
            return AddressList;
        }

        public List<Address> GetByCondition(Expression<Func<Address, bool>> lambda)
        {
            return db.Addresses.Where(x => x.IsActive == true).Where(lambda).ToList();
        }

        public Address GetByFind(Expression<Func<Address, bool>> lambda)
        {
            return db.Addresses.FirstOrDefault(lambda);
        }

        public int Update(Address deger)
        {
            Address _address = Detail(deger.AddressID);
            _address = deger;
            _address.UpdateDate = DateTime.Now;
            return db.SaveChanges();
        }
    }
}
