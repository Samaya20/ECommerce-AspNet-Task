﻿using ECommerce.Core.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.DataAccess
{
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        //x=>x.Id==10
        Task<T> Get(Expression<Func<T, bool>> filter);
        Task<List<T>> GetList(Expression<Func<T, bool>> filter=null);
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
