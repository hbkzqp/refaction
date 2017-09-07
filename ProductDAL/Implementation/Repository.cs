using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;

namespace ProductDAL.Repository
{
    public class Repository<T, V> : IRepository<T, V> where T : class

    {
        protected readonly DbContext _Context;

        public Repository(DbContext context)
        {
            this._Context = context;
        }
        public T Get(V Id)
        {
            return this._Context.Set<T>().Find(Id);
        }

        public IEnumerable<T> GetAll()
        {
            return this._Context.Set<T>().ToList();
        }
        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _Context.Set<T>().Where(predicate);
        }

        public T SingleOrDefault(Expression<Func<T, bool>> predicate)
        {
            return _Context.Set<T>().SingleOrDefault(predicate);
        }
        public void Add(T entity)
        {
            this._Context.Set<T>().Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _Context.Set<T>().AddRange(entities);
        }

        public void Remove(T entity)
        {
            _Context.Set<T>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _Context.Set<T>().RemoveRange(entities);
        }

        public void RemoveByKey(V key)
        {
            T entity = this.Get(key);
            _Context.Set<T>().Remove(entity);
        }
    }
}
