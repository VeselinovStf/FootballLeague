﻿using FootballLeague.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootballLeague.Core.Interfaces
{
    public interface IAsyncRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(string id);

        T GetSingleBySpec(ISpecification<T> spec);

        IEnumerable<T> GetAllBySpec(ISpecification<T> spec);

        Task<IReadOnlyList<T>> ListAllAsync();

        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);

        Task<T> AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);

        Task<int> CountAsync(ISpecification<T> spec);
    }
}