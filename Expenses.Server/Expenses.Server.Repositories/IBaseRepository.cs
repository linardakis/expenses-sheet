namespace Expenses.Server.Repositories
{
    public interface IBaseRepository<T>
    {
        T Get(int id);
        IEnumerable<T> Get();
        T Create(T entity);
        T Update(T entity);
        bool Delete(int id);

    }
}