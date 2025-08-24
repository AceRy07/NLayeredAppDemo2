using Northwind.DataAccess.Abstract;
using Northwind.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAccess.Concrete.EntityFramework
{
    // Tüm CRUD operasyonları için işlemler tanımlandı
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        // Her bir tanımladığımız genericler için ayrı
        // kısıtlamalar getirebiliriz.
        where TEntity :class, IEntity, new()
        where TContext:DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                // Insert, Update, Delete için
                // Entry method vardır.
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                // Insert, Update, Delete için
                // Entry method vardır.
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using(TContext context = new TContext())
            {
                return filter == null ?
                    context.Set<TEntity>().ToList() :
                     context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public TEntity GetId(Expression<Func<TEntity, bool>> filter)
        {
            using(TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                // Insert, Update, Delete için
                // Entry method vardır.
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
