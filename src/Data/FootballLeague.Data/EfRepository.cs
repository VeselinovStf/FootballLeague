using FootballLeague.Core.Entities;
using FootballLeague.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballLeague.Data
{
    /// <summary>
    /// Note: Preserve deleted entities id db - Entities are filtered on IsDeleted = false, Except for specifications
    /// </summary>
    public class EfRepository<T> : IAsyncRepository<T> where T : BaseEntity
    {
        protected readonly FootballLeagueDbContext _dbContext;

        public EfRepository(FootballLeagueDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync(e => e.Id == id && !e.IsDeleted);
        }

        public async Task<T> GetSingleBySpecAsync(ISpecification<T> spec)
        {
            return new List<T>(await ListAsyncBySpecAsync(spec)).FirstOrDefault();
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().Where(e => !e.IsDeleted).ToListAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsyncBySpecAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        public async Task<int> CountAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).CountAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            // Preserve Entity - Set that is deleted
            entity.IsDeleted = true;
            _dbContext.Entry(entity).State = EntityState.Modified;
            
            await _dbContext.SaveChangesAsync();
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_dbContext.Set<T>().AsQueryable(), spec);
        }


    }
}
