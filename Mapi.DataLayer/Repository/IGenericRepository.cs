﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mapi.DataLayer.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> Get(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params Expression<Func<T, object>>[] includeProperties);
        T GetById(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        void Insert(T entity);
        void Delete(object id);
        void Delete(T entity);
        void Update(T entity);
    }
}
