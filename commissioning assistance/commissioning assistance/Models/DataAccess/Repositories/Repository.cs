using commissioning_assistance.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commissioning_assistance.Models.DataAccess.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            Context = context;
        }

        void IRepository<TEntity>.Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        void IRepository<TEntity>.AddRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().AddRange(entities);
        }

        IEnumerable<TEntity> IRepository<TEntity>.GetEntities()
        {
            return Context.Set<TEntity>().ToList();
        }

        TEntity IRepository<TEntity>.GetEntity(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        void IRepository<TEntity>.Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        void IRepository<TEntity>.RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
        }
    }
}
