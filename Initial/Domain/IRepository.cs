using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Initial.Domain
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);

        TEntity Get<TIn>(TIn id);

        TEntity FindSingle(Expression<Func<TEntity, bool>> filter);

        ICollection<TEntity> FindAll(Expression<Func<TEntity, bool>> filter);

        IQueryable<TEntity> GetQueryable();
    }
}
