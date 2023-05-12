using Expenses.Server.Entities;
using Expenses.Server.Repositories.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.Server.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly ExpensesDBContext _db;
        public BaseRepository(ExpensesDBContext db)
        {
            _db = db;
        }
        public virtual T Create(T entity)
        {
            _db.Set<T>().Add(entity);
            _db.SaveChanges();
            return entity;
        }

        public virtual void Delete(int id)
        {
            var entity = _db.Set<T>().SingleOrDefault(x => x.Id == id);
            if(entity != null)
            {
                _db.Set<T>().Remove(entity);
                _db.SaveChanges();
            }
        }

        public virtual IEnumerable<T> Get()
        {
            return _db.Set<T>().ToList();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return _db.Set<T>().Where(predicate).ToList();
        }

        public T GetById(int id)
        {
            return _db.Set<T>().SingleOrDefault(x => x.Id == id);
        }

        public virtual T Update(T entity)
        {
            _db.Set<T>().Update(entity);
            _db.SaveChanges();
            return entity;
        }
    }
}
