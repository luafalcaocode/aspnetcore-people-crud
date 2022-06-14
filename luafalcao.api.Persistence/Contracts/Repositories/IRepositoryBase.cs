﻿using System;
using System.Linq;
using System.Linq.Expressions;

namespace luafalcao.api.Persistence.Contracts
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
