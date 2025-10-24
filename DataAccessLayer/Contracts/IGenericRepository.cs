using BusinessAccessLayes.Specification;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Contracts
{
    public interface IGenericRepository<IEntity, TKey> where IEntity : BaseOfAllContentEntities<TKey>
    {
        Task<IEnumerable<IEntity>> GetAllAsync(ISpecification<IEntity, TKey> specification);
        Task<IEntity?> GetByIdAsync(TKey id);
        Task<IEnumerable <IEntity>> GetAllAsync();
        Task AddAsync(IEntity entity);
        public void Update(IEntity entity);
        public void Delete(IEntity entity);

    }
}
