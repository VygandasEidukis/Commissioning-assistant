using System.Collections.Generic;

namespace commissioning_assistance.Core.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetEntity(int id);
        IEnumerable<TEntity> GetEntities();

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        void Reset();
    }
}
