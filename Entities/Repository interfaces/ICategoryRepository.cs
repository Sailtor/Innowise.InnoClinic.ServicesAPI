﻿using Core.Entities;

namespace Core.RepositoryInterfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Category> GetByIdAsync(Guid categoryId, CancellationToken cancellationToken = default);
        Task<Category> AddAsync(Category category, CancellationToken cancellationToken = default);
        void Update(Category category);
        void Remove(Category category);
    }
}
