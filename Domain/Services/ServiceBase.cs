using Data.Interface;
using Domain.Interfaces;
using Infra.Helpers;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServiceBase<T> : IDisposable, IServiceBase<T> where T : class
    {
        private readonly IRepository<T> _repository;
        public ServiceBase(IRepository<T> repository)
        {
            _repository = repository;
        }

        public void Add(T obj)
        {
            Transaction(() =>
                {
                    _repository.Add(obj);
                    _repository.SaveAll();
                }
            );
        }

        public Task<PageList<T>> AllAsync(PageParams pageParams)
        {
            return _repository.AllAsync(pageParams);
        }

        Task<T> IServiceBase<T>.AddAsync(T entity)
        {
            return _repository.Add(entity);
        }

        public void Delete(Func<T, bool> predicate)
        {
            Transaction(() =>
                {
                    _repository.Delete(predicate);
                    _repository.SaveAll();
                }
            );
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

        public T Find(params object[] key)
        {
            return _repository.Find(key);
        }

        public T Get(Func<T, bool> predicate, params Expression<Func<T, object>>[] includes)
        {
            return _repository.Get(predicate, includes);
        }

        public IQueryable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public T GetLastOrderByDescending(Expression<Func<T, object>> a)
        {
            return _repository.GetLastOrderByDescending(a);
        }

        public void SaveAll()
        {
            _repository.SaveAll();
        }

        public void Update(T obj)
        {
            Transaction(() =>
                {
                    _repository.Update(obj);
                    _repository.SaveAll();
                }
            );
        }

        protected void Transaction(Action method)
        {
            _repository.BeginTransaction();

            try
            {
                method();
                _repository.Commit();
            }
            catch (Exception ex)
            {
                _repository.RollbackTransaction();
                throw ex;
            }
        }
    }
}
