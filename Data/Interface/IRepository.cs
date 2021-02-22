using Infra.Helpers;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Data.Interface
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T Get(Func<T, bool> predicate, params Expression<Func<T, object>>[] includes);
        Task<PageList<T>> AllAsync(PageParams pageParams);
        T Find(params object[] key);
        void Update(T obj);
        Task<T> Add(T entity);
        T GetLastOrderByDescending(Expression<Func<T, object>> a);
        void Delete(Func<T, bool> predicate);
        void Dispose();
        void BeginTransaction();
        void Commit();
        void RollbackTransaction();
        void SaveAll();
    }
}
