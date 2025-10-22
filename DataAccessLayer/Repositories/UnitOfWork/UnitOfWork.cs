using DataAccessLayer.Contracts;
using DataAccessLayer.Data.Contexts;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.UnitOfWork
{
    public class UnitOfWork(MasaqDbContext _dbContext) : IUnitOfWork
    {
        private readonly Dictionary<string, object> _repositories = new Dictionary<string, object>();

        public IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : BaseOfAllContentEntities<TKey>
        {

            var typeName = nameof(TEntity);
            if (_repositories.ContainsKey(typeName))
                return (IGenericRepository<TEntity, TKey>)_repositories[typeName];
            //create repo object
            var repo = new GenericRepository<TEntity, TKey>(_dbContext);
            //store Refernce from Repo object
            _repositories[typeName] = repo;
            return (repo);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
