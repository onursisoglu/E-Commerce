using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Jewelery.DAL.Entity;

namespace Jewelery.BLL.Repository
{
   public  class BaseRepository
    {

        private static JewelryEntities Db;

        protected JewelryEntities db
        {
            get
            {
                if (Db==null)
                
                    Db = new JewelryEntities();
                    return Db;
                
            }

            set
            {
                Db = value;
            }
        }

        public int Save()
        {
            return db.SaveChanges();

        }

    }
}
