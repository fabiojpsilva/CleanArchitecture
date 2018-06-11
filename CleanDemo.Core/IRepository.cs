using System;
using System.Collections.Generic;
using System.Text;

namespace CleanDemo.Core
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        TEntity Get(int id);
        IEnumerable<TEntity> All { get; }
        int Save(TEntity entity);
    }
}
