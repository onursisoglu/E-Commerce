using Jewelery.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Jewelery.BLL.Repository
{
  public  class CommentRepository : BaseRepository, IRepository<Comment>
    {
        public int Add(Comment deger)
        {
            deger.IsActive = true;
            deger.AddedDate = DateTime.Now;
            db.Comments.Add(deger);
            return db.SaveChanges();
        }

        public int Delete(int id)
        {
            Comment _comment = Detail(id);
            if (_comment != null)
            {
                _comment.IsActive = false;

                return db.SaveChanges();
            }
            return 0;
        }

        public Comment Detail(int id)
        {
            Comment _comment = db.Comments.Find(id);
            return _comment;
        }

        public List<Comment> GetAll()
        {
            List<Comment> CommentList = db.Comments.ToList();
            return CommentList;
        }

        public List<Comment> GetByCondition(Expression<Func<Comment, bool>> lambda)
        {
            return db.Comments.Where(x => x.IsActive == true).Where(lambda).ToList();
        }

        public Comment GetByFind(Expression<Func<Comment, bool>> lambda)
        {
            return db.Comments.FirstOrDefault(lambda);
        }

        public int Update(Comment deger)
        {
            Comment _comment = Detail(deger.ID);
            _comment = deger;
            return db.SaveChanges();
        }
    }
}
