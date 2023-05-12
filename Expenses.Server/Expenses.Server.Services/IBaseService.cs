using System.Linq.Expressions;

namespace Expenses.Server.Services
{
    public interface IBaseService<T> where T : class
    {
        IEnumerable<T> Get();
        IEnumerable<T> Get(Expression<Func<T,bool>> predicate);
        T GetById(int id);
        T Create(T entity);
        T Update(T entity);
        void Delete(int id);

    }
}