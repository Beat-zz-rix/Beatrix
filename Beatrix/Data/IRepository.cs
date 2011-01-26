using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beatrix.Data
{
    public interface IRepository<TEntity, TKey>
        where TEntity : class
    {
        TEntity SingleOrDefault(Func<TEntity, bool> predicate);
        
        IEnumerable<TEntity> GetList(Func<TEntity, bool> predicate);

        TEntity Insert(TEntity entity);

        TEntity Update(TEntity entity);

        void Delete(TEntity entity);

        void Delete(TKey id);
    }
}
