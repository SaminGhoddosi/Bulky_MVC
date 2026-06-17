using Ardalis.Specification;
using Bulky.Domain.Interfaces.IServices;
using Bulky.Domain.Interfaces.Models;
using Bulky.Domain.Interfaces.Repository;
using Bulky.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.Domain.Services
{
    public class DomainService<TEntity> : IDisposable, IDomainService<TEntity> where TEntity : IEntity
    {
        private readonly IRepository<TEntity> _repository;

        public DomainService(IRepository<TEntity> repository)
        {
            _repository = repository;
        }
        
        public Task<TEntity> AddAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync(ISpecification<TEntity> spec)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void DetachAll()
        {
            throw new NotImplementedException();
        }

        public void DetachLocal(Func<TEntity, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public int ExecuteSql(string sql)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> FirstAsync(ISpecification<TEntity> spec)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> FirstOrDefaultAsync(ISpecification<TEntity> spec)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<TEntity>> ListAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PagedResult<TEntity>> ListAllPagedAsync(int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<TEntity>> ListAsync(ISpecification<TEntity> spec)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResult<TEntity>> ListPagedAsync(ISpecification<TEntity> spec, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public void Seed(IEnumerable<TEntity> data)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
