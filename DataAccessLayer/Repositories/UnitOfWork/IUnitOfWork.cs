using DataAccessLayer.Contracts;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.UnitOfWork
{
    public interface IUnitOfWork
    {
        IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : BaseOfAllContentEntities<TKey>;
        Task<int> SaveChangesAsync();
    }
}
