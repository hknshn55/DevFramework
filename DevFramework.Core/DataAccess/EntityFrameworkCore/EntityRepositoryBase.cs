using DevFramework.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.DataAccess.EntityFrameworkCore
{
    public class EntityRepositoryBase<TEntity> : IEntityRepository<TEntity> where TEntity : class, IEntity, new()
    {
        private readonly DbContext _context;
        DbSet<TEntity> set;
        public EntityRepositoryBase(DbContext context)
        {
            _context = context;
            set = context.Set<TEntity>();
        }

        public TEntity Add(TEntity entity)
        {
            set.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(TEntity entity)
        {
            set.Remove(entity);
            _context.SaveChanges();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> expression)
        {
            return set.SingleOrDefault(expression);
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> expression = null)
        {
            return expression ==null ?set.ToList() : set.Where(expression).ToList();
        }

        public TEntity Update(TEntity entity)
        {
            set.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
