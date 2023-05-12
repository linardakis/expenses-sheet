﻿using System.Linq.Expressions;

namespace Expenses.Server.Repositories
{
    public interface IBaseRepository<T>
    {
        T GetById(int id);
        IEnumerable<T> Get();
        IEnumerable<T> Get(Expression<Func<T,bool>> predicate);
        T Create(T entity);
        T Update(T entity);
        void Delete(int id);

    }
}