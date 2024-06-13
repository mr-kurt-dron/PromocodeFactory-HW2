using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PromoCodeFactory.Core.Abstractions.Repositories;
using PromoCodeFactory.Core.Domain;
namespace PromoCodeFactory.DataAccess.Repositories
{
    public class InMemoryRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected IEnumerable<T> Data { get; set; }

        public InMemoryRepository(IEnumerable<T> data)
        {
            Data = data;
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            return Task.FromResult(Data);
        }

        public Task<T> GetByIdAsync(Guid id)
        {
            return Task.FromResult(Data.FirstOrDefault(x => x.Id == id));
        }

        public Task<Guid> CreateAsync(T entity)
        {
            var newEntity = entity;
            newEntity.Id = Guid.NewGuid();
            Data = Data.Append(newEntity);
            return Task.FromResult(newEntity.Id);
        }

        public Task<T> UpdateAsync(Guid id, T entity)
        {
            var newEntity = entity;
            newEntity.Id = id;

            var selectedEntity = Data.FirstOrDefault(x => x.Id == id);
            if (selectedEntity == null)
            {
                throw new KeyNotFoundException($"Employee with id: {id} not found");
            }

            var newData = Data.Where(x => x.Id != id);
            Data = newData.Append(newEntity);

            return Task.FromResult(newEntity);
        }

        public Task DeleteAsync(Guid id)
        {
            if (!Data.Any(x => x.Id == id))
            {
                throw new KeyNotFoundException($"Employee with id: {id} not found");
            }
            var newData = Data.Where(x => x.Id != id);

            Data = newData;
            return Task.CompletedTask;
        }
    }
}