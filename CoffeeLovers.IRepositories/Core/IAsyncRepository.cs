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

        Task<int> CountAsync();

        Task<T> FindAsync(Expression<Func<T, bool>> match);

        void ApplyPatch<T>(T entityName, List<PatchDto> patchDtos) where T : BaseEntity;

        void SoftDeleteAsync(T entity);

        Task<int> SaveAllwithAudit(string authId = Constants.CreatedBy);

        Task AddAsync(T entity);
    }
}