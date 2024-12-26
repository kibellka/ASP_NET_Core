using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PromoCodeFactory.Core.Abstractions.Repositories;
using PromoCodeFactory.Core.Domain;

namespace PromoCodeFactory.DataAccess.Repositories
{
    public class EfRepository<T> : IRepository<T>
        where T : BaseEntity
    {
        private readonly DataContext _dbContext;
        private readonly DbSet<T> _entitySet;

        public EfRepository(DataContext dataContext)
        {
            _dbContext = dataContext;
            _entitySet = _dbContext.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var entities = await _entitySet.ToListAsync();

            return entities;
        }

        public async Task<IEnumerable<T>> GetByIdsAsync(IEnumerable<Guid> ids)
        {
            var entities = await _entitySet
                .Where(e => ids.Contains(e.Id))
                .ToListAsync();

            return entities;
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            var entity = await _entitySet.FirstOrDefaultAsync(e => e.Id == id);

            return entity;
        }

        public async Task<T> AddAsync(T entity)
        {
            var entityEntry = await _entitySet.AddAsync(entity);
            await SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _entitySet.Update(entity);
            await SaveChangesAsync();

            return entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var obj = _entitySet.Find(id);

            if (obj == null)
                return false;

            _entitySet.Remove(obj);
            await SaveChangesAsync();

            return true;
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
