using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Bulky.DataAcess.Data;
using Bulky.Domain.Interfaces.Models;
using Bulky.Domain.Interfaces.Repository;
using Bulky.Paging;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository
{
    public class RepositoryBase<TEntity> : IDisposable, IRepository<TEntity> where TEntity : class, IEntity
    {
        protected readonly AppDbContext _dbContext;
        protected readonly DbSet<TEntity> _dbContextSet;

        public RepositoryBase(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbContextSet = _dbContext.Set<TEntity>();
        }
        public async Task<TEntity> AddAsync(TEntity entity)
        {
             await _dbContext.Set<TEntity>().AddAsync(entity);
             await _dbContext.SaveChangesAsync();
             return entity;
        }


        public async Task AddRangeAsync(params TEntity[] entities)
        {
            if (entities.Any())
            {
                await Task.Run(() => _dbContext.AddRangeAsync(entities));
            }
        }

        public async Task BulkInsertAsync(IList<TEntity> entities)
        {
            await _dbContext.AddRangeAsync(entities);
        }

        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbContextSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task<int> CountAsync(ISpecification<TEntity> spec)
        {
            var specificationResult = ApplySpecification(spec);
            return await specificationResult.CountAsync();
        }

        public async Task<int> DeleteAsync(TEntity entity)
        {
            DetachAll();
            _dbContextSet.Remove(entity);
            return await _dbContext.SaveChangesAsync();
        }

        public void DetachAll()
        {
            foreach(var entry in _dbContext.ChangeTracker.Entries().ToList())
            {
                _dbContext.Entry(entry.Entity).State = EntityState.Detached;
            }
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public async Task<int> ExecuteSqlAsync(string sql)
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();

            try
            {
                var result = await _dbContext.Database.ExecuteSqlRawAsync(sql);
                await transaction.CommitAsync();
                return result;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<TEntity> FirstAsync(ISpecification<TEntity> spec)
        {
            var specificationResult = ApplySpecification(spec);
            return await specificationResult.FirstAsync();
        }

        public async Task<TEntity> FirstOrDefaultAsync(ISpecification<TEntity> spec)
        {
            var specificationResult = ApplySpecification(spec);
            return await specificationResult.FirstAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> ListAllAsync()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public Task<PagedResult<TEntity>> ListAllPagedAsync(int page, int pageSize)
        {
            var list = _dbContext.Set<TEntity>().GetPaged(page, pageSize);
            return Task.FromResult(list);
        }

        public async Task<IEnumerable<TEntity>> ListAsync(ISpecification<TEntity> spec)
        {
            var specificationResult = ApplySpecification(spec);
            return await specificationResult.ToListAsync();
        }

        public async Task<PagedResult<TEntity>> ListPagedAsync(ISpecification<TEntity> spec, int page, int pageSize)
        {
            var specificationResult = ApplySpecification(spec);
            return await Task.FromResult(specificationResult.GetPaged(page, pageSize));
        }

        public IQueryable<TEntity> ApplySpecification(ISpecification<TEntity> spec)
        {
            return SpecificationEvaluator.Default.GetQuery(_dbContextSet.AsQueryable(), spec);
        }

        public async Task RemoverInt(int id)
        {
            var obj = _dbContextSet.Find(id);
            _dbContextSet.Remove(obj);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            return await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateRangeAsync(params TEntity[] entities)
        {
            if (entities.Any())
            {
                await Task.Run(() => _dbContext.UpdateRange(entities));
            }
        }
    }
}
