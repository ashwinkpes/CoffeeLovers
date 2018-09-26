using CoffeeLovers.Common;
using CoffeeLovers.DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CoffeeLovers.IRepositories
{
    public interface IAsyncRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<List<T>> ListAllAsync();
        Task<List<T>> ListAsync(ISpecification<T> spec);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<int> CountAsync();
        Task<T> FindAsync(Expression<Func<T, bool>> match);
        Task ApplyPatchAsync<T>(T entityName, List<PatchDto> patchDtos) where T : BaseEntity;
        Task SoftDeleteAsync(T entity);
        Task<int> SaveAll();        
    }
}
