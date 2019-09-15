using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SHBL.SPT.BASE.Repository
{
    public interface IRepository
    {
        DbContext BaseContext { get; set; }
    }

    public interface IRepository<T> : IRepository
        where T : class
    {
        IQueryable<T> GetAll();
        T FindById(object id);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Delete(T entity);
        void Edit(T entity);
    }
}
