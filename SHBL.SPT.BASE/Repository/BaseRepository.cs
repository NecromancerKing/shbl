using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace SHBL.SPT.BASE.Repository
{
    public abstract class BaseRepository<C, T> :
        IRepository<T>
        where T : class
        where C : DbContext
    {

        private DbContext _baseContext;
        public virtual DbContext BaseContext
        {
            get { return _baseContext; }
            set { _baseContext = value; }
        }

        public C Context
        {
            get
            {
                return BaseContext as C;
            }
        }

        public virtual IQueryable<T> GetAll()
        {
            IQueryable<T> query = BaseContext.Set<T>();
            return query;
        }

        public T FindById(object i)
        {
            T query = BaseContext.Set<T>().Find(i);
            return query;
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = BaseContext.Set<T>().Where(predicate);
            return query;
        }

        public virtual void Add(T entity)
        {
            BaseContext.Set<T>().Add(entity);
        }

        public virtual void AddRange(IEnumerable<T> entities)
        {
            BaseContext.Set<T>().AddRange(entities);
        }

        public virtual void Delete(T entity)
        {
            BaseContext.Set<T>().Remove(entity);
        }

        public virtual void Edit(T entity)
        {
            BaseContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
