using Ardalis.Specification;
using Bulky.Domain.Interfaces.Models;
using System;
using System.Linq.Expressions;

namespace Bulky.Domain.Interfaces.Repository
{
    public interface IRepository<TEntity> : IDisposable where TEntity : IEntity
    {
        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> ListAllAsync();
        Task<IEnumerable<TEntity>> ListAsync(ISpecification<TEntity> spec);
        Task<PagedResult<TEntity>> ListAllPagedAsync(int page, int pageSize);
        Task<PagedResult<TEntity>> ListPagedAsync(ISpecification<TEntity> spec, int page, int pageSize);
        Task<TEntity> AddAsync(TEntity entity);
        Task<int> UpdateAsync(TEntity entity);
        Task BulkInsertAsync(IList<TEntity> entities);
        Task<int> DeleteAsync(TEntity entity);
        Task<int> CountAsync(ISpecification<TEntity> spec);
        Task<TEntity> FirstAsync(ISpecification<TEntity> spec);
        Task<TEntity> FirstOrDefaultAsync(ISpecification<TEntity> spec);
        void Seed(IEnumerable<TEntity> data);
        void DetachLocal(Func<TEntity, bool> predicate);
        void DetachAll();
        int ExecuteSql(string sql);
        Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);
        Task RemoverInt(int id);
        Task UpdateRangeAsync(params TEntity[] entities);
        Task AddRangeAsync(params TEntity[] entities);
        void UpdateRange(params TEntity[] entities);
        void AddRange(params TEntity[] entities);
    }
}
