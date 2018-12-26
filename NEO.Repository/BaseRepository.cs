using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using NEO.Common;

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

        public bool Exists(Expression<Func<TEntity, bool>> expression)
        {
            return DbContext.Set<TEntity>().Any(expression);
        }

        public TEntity Get(Expression<Func<TEntity,bool>> expression)
        {
            return DbContext.Set<TEntity>().FirstOrDefault(expression);
        }

        public Pager<TEntity> GetPageList<TKey>(Expression<Func<TEntity, bool>> expression,int pageIndex,int pageSize, Expression<Func<TEntity, TKey>> orderBy = null,bool isAsc = true)
        {
            var pager = new Pager<TEntity>();
            var pages = DbContext.Set<TEntity>().AsNoTracking().Where(expression);
            if (orderBy != null)
            {
                pages = isAsc ? pages.OrderBy(orderBy) : pages.OrderByDescending(orderBy);
            }

            pager.PageIndex = pageIndex;
            pager.PageSize = pageSize;
            pager.Total = pages.Count();
            pager.Data = pages.Skip((pageIndex-1)*pageSize).Take(pageSize).ToList();
            
            return pager;
        }

        public string GetEntityState(TEntity entity)
        {
            return DbContext.Entry(entity).State.ToString();
        }
    }

}
