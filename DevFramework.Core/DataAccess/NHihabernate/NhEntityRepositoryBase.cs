using DevFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.DataAccess.NHihabernate
{
    public class NhEntityRepositoryBase<TEntity>:IEntityRepository<TEntity> 
        where TEntity:class,IEntity,new()
    {
       private NHibernateHelper _nHibernateHelper;

        public NhEntityRepositoryBase(NHibernateHelper nHibernateHelper)
        {
            _nHibernateHelper = nHibernateHelper;
        }

        public TEntity Add(TEntity entity)
        {
            using (var session = _nHibernateHelper.OpenSession())
            {
                session.Save(entity);
                return entity;
            }
        }

        public void Delete(TEntity entity)
        {
            using (var session = _nHibernateHelper.OpenSession())
            {
                session.Delete(entity);
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> expression)
        {
              using (var session = _nHibernateHelper.OpenSession())
              {
                return session.Query<TEntity>().SingleOrDefault(expression);
              }
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> expression = null)
        {
            using (var session = _nHibernateHelper.OpenSession())
            {
                return expression == null ? session.Query<TEntity>().ToList()
                    : session.Query<TEntity>().Where(expression).ToList();
            }
        }

        public TEntity Update(TEntity entity)
        {
            using (var session = _nHibernateHelper.OpenSession())
            {
                session.Update(entity);
                return entity;
            }
        }
    }
}
