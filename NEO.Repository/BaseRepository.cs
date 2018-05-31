using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using NEO.Common.Log;

namespace NEO.Repository
{
    public class BaseRepository<TEntity> where TEntity : class
    {
        public NeoContext DbContext { get; }

        public BaseRepository(NeoContext context)
        {
            DbContext = context;
        }

        public TEntity Insert(TEntity entity)
        {
            return DbContext.Set<TEntity>().Add(entity);
        }

        public IEnumerable<TEntity> Insert(IEnumerable<TEntity> entities)
        {
            return DbContext.Set<TEntity>().AddRange(entities);
        }

        public void Delete(TEntity entity)
        {
            DbContext.Set<TEntity>().Remove(entity);
        }

        public void Delete(IList<TEntity> entities)
        {
            DbContext.Set<TEntity>().RemoveRange(entities);
        }

        public TEntity Get(Expression<Func<TEntity,bool>> expression)
        {
            return DbContext.Set<TEntity>().FirstOrDefault(expression);
        }

        public string GetEntityState(TEntity entity)
        {
            return DbContext.Entry(entity).State.ToString();
        }
    }
}
