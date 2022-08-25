using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace SHBL.SPT.BASE.Repository
{
    public abstract class RepositoryBase<C, T> :
        IRepository<T>
        where T : class
        where C : DbContext
    {
        public virtual DbContext BaseContext { get; set; }

        public C Context => BaseContext as C;

        public virtual IQueryable<T> GetAll()
        {
            return BaseContext.Set<T>();
        }

        public T FindById(object i)
        {
            return BaseContext.Set<T>().Find(i);
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return BaseContext.Set<T>().Where(predicate);
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
