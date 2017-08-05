using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Jewelery.BLL.Repository
{
   interface IRepository<T>
    {
        List<T> GetAll();

        T Detail(int id);

        int Add(T deger);

        int Update(T deger);

        int Delete(int id);

        List<T> GetByCondition(Expression<Func<T, bool>> lambda);

        T GetByFind(Expression<Func<T, bool>> lambda);

    }
}
