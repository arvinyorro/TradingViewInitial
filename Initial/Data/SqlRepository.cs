using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Initial.Domain;

namespace Initial.Data
{
    public class SqlRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly HorizonContext _horizonContext;

        public SqlRepository(HorizonContext context)
        {
            _horizonContext = context;
        }

        public void Add(TEntity entity)
        {
            _horizonContext.Set<TEntity>().Add(entity);
        }

        public TEntity Get<TIn>(TIn id)
        {
            return _horizonContext.Set<TEntity>().Find(id);
        }

        public TEntity FindSingle(Expression<Func<TEntity, bool>> filter)
        {
            return this._horizonContext.Set<TEntity>().FirstOrDefault(filter);
        }

        public ICollection<TEntity> FindAll(Expression<Func<TEntity, bool>> filter)
        {
            return this._horizonContext.Set<TEntity>().Where(filter).ToList();
        }

        public IQueryable<TEntity> GetQueryable()
        {
            return this._horizonContext.Set<TEntity>();
        }
    }
}
