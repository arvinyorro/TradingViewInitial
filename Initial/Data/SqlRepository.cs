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
        private readonly BinanceBotContext _binanceBotContext;

        public SqlRepository(BinanceBotContext context)
        {
            _binanceBotContext = context;
        }

        public void Add(TEntity entity)
        {
            _binanceBotContext.Set<TEntity>().Add(entity);
        }

        public TEntity Get<TIn>(TIn id)
        {
            return _binanceBotContext.Set<TEntity>().Find(id);
        }

        public TEntity FindSingle(Expression<Func<TEntity, bool>> filter)
        {
            return this._binanceBotContext.Set<TEntity>().FirstOrDefault(filter);
        }

        public ICollection<TEntity> FindAll(Expression<Func<TEntity, bool>> filter)
        {
            return this._binanceBotContext.Set<TEntity>().Where(filter).ToList();
        }

        public IQueryable<TEntity> GetQueryable()
        {
            return this._binanceBotContext.Set<TEntity>();
        }
    }
}
