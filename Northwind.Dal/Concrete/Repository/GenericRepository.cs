using Microsoft.EntityFrameworkCore;
using Northwind.Dal.Abstract;
using Northwind.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Dal.Concrete.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : EntityBase
    {
        #region Variables
        protected DbContext context;
        protected DbSet<T> dbset;
        #endregion
        public GenericRepository(DbContext context)
        {
            this.context = context;
            this.dbset = this.context.Set<T>();
        }

        public T Add(T item)
        {
            throw new NotImplementedException();
        }

        public Task<T> AddAsync(T item)
        {
            throw new NotImplementedException();
        }

        public bool DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public T Find(int id)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetQueryable()
        {
            throw new NotImplementedException();
        }

        public T Update(T item)
        {
            throw new NotImplementedException();
        }

        public Task<T> UpdateAsync(T item)
        {
            throw new NotImplementedException();
        }
    }
}
