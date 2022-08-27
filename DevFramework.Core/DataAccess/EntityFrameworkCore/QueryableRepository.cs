using DevFramework.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.DataAccess.EntityFrameworkCore
{
    //Context kapanmadan bir kaç işlem yapabileceğiz.
    public class QueryableRepository<T> : IQueryableRepository<T> where T : class, IEntity, new()
    {
        private readonly DbContext _context;
        private DbSet<T> _entities;

        public QueryableRepository(DbContext context)
        {
            _context = context;
        }

        //public IQueryable<T> Table => this.Entities (Expressionbody)
        public IQueryable<T> Table
        {
            get {
                return this.Entities;
                }
        }

        //Dİğer sınıflar kullanamayacak protected
        protected virtual DbSet<T> Entities 
        {
          //get{return _entities ??(_entities=_context.Set<T>());}
          get {
                if (_entities == null)
                {
                    _entities = _context.Set<T>();
                }
                return _entities;
              }
        }
    }
}
