using Data.Interface;
using Infra.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Data
{
    public class Repository<T> : IDisposable, IRepository<T> where T : class
    {
        private readonly TesteContext _testeContext;

        private readonly DbSet<T> _table;

        public Repository(TesteContext testeContext)
        {
            _testeContext = testeContext;
            _table = _testeContext.Set<T>();
        }

        public async Task<PageList<T>> AllAsync(PageParams pageParams)
        {
            return await PageList<T>.CreateAsync(_table, pageParams.PageNumber, pageParams.PageSize);
        }

        public async Task<T> Add(T entity)
        {
            var t = (await _table.AddAsync(entity)).Entity;
            SaveChanges();
            return t;
        }

        public async void Add(IEnumerable<T> entities)
        {
            await _table.AddRangeAsync(entities);
            SaveChanges();
        }


        public void Delete(Func<T, bool> predicate)
        {
            _table.Where(predicate).ToList()
                .ForEach(del => _table.Remove(del));
            SaveChanges();
        }

        public void SaveChanges()
        {
            _testeContext.SaveChanges();
        }

        public void Dispose()
        {
            _testeContext.Dispose();
        }

        public void BeginTransaction()
        {
            _testeContext.Database.BeginTransaction();
        }

        public void Commit()
        {
            _testeContext.Database.CommitTransaction();
        }

        public void RollbackTransaction()
        {
            _testeContext.Database.RollbackTransaction();
        }
        public IQueryable<T> GetAll()
        {
            return _table;
        }

        public T GetLastOrderByDescending(Expression<Func<T, object>> a)
        {
            return _table.OrderByDescending(a).FirstOrDefault();
        }

        public T Get(Func<T, bool> predicate, params Expression<Func<T, object>>[] includes)
        {
            var query = _table.AsQueryable();

            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }

            query = query.Where(predicate).AsQueryable();

            return query.FirstOrDefault();
        }

        public T Find(params object[] key)
        {
            return _table.Find(key);
        }

        public void Update(T obj)
        {
            _testeContext.Entry(obj).State = EntityState.Modified;
        }

        public void SaveAll()
        {
            _testeContext.SaveChanges();
        }
    }
}
