using Infra.Helpers;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IServiceBase<T> where T : class
    {
        Task<PageList<T>> AllAsync(PageParams pageParams);

        Task<T> AddAsync(T entity);

        IQueryable<T> GetAll();

        T Get(Func<T, bool> predicate, params Expression<Func<T, object>>[] includes);

        T Find(params object[] key);

        void Update(T entity);

        void SaveAll();

        void Add(T entity);

        void Delete(Func<T, bool> predicate);

        T GetLastOrderByDescending(Expression<Func<T, object>> a);

    }
}
