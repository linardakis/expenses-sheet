using Expenses.Server.Repositories;
using System.Linq.Expressions;

namespace Expenses.Server.Services
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        private readonly IBaseRepository<T> _baseRepository;
        public BaseService(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public T Create(T entity)
        {
            return _baseRepository.Create(entity);
        }

        public void Delete(int id)
        {
            _baseRepository.Delete(id);
        }

        public IEnumerable<T> Get()
        {
            return _baseRepository.Get();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return _baseRepository.Get(predicate);
        }

        public T GetById(int id)
        {
            return _baseRepository.GetById(id);
        }

        public T Update(T entity)
        {
            return _baseRepository.Update(entity);
        }
    }
}