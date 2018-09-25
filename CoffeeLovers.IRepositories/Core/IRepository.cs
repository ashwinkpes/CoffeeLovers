using CoffeeLovers.DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CoffeeLovers.IRepositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        T GetById(int id);
        T GetSingleBySpec(ISpecification<T> spec);
        IEnumerable<T> ListAll();
        IEnumerable<T> List(ISpecification<T> spec);
        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        int Count();
        T Find(Expression<Func<T, bool>> match);        
    }
}
