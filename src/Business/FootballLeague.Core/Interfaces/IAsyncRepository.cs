using FootballLeague.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootballLeague.Core.Interfaces
{
    public interface IAsyncRepository<T> where T : BaseEntity
    {
        // TODO: IDeletable IsDeleted is not looked through all methods!
        Task<T> GetByIdAsync(int id);

        T GetSingleBySpec(ISpecification<T> spec);

        Task<IReadOnlyList<T>> ListAllAsync();

        Task<IReadOnlyList<T>> ListAsyncBySpec(ISpecification<T> spec);

        Task<T> AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);

        Task<int> CountAsync(ISpecification<T> spec);
    }
}
