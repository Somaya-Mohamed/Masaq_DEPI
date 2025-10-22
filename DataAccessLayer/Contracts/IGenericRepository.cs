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
        Task<IEnumerable<IEntity>> GetAllAsync();
        Task<IEntity?> GetByIdAsync(TKey id);
        Task AddAsync(IEntity entity);
        public void UpdateAsync(IEntity entity);
        public void DeleteAsync(IEntity entity);

    }
}
