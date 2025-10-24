using BusinessAccessLayes.Specification;
using DataAccessLayer.Data.Contexts;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Contracts
{
    public class GenericRepository<IEntity, TKey> (MasaqDbContext dbContext): IGenericRepository<IEntity, TKey> where IEntity : BaseOfAllContentEntities<TKey>
    {
        public async Task AddAsync(IEntity entity)
        {
           await dbContext.Set<IEntity>().AddAsync(entity);
        }


        public async Task<IEnumerable<IEntity>> GetAllAsync(ISpecification<IEntity, TKey> specification)
        {
            return await SpecificationEvaluator.CreateQuery(specification, dbContext.Set<IEntity>()).ToListAsync();
        }

        public async Task<IEntity?> GetByIdAsync(TKey id)
        {
            return await dbContext.Set<IEntity>().FindAsync(id);
        }

        public void Update(IEntity entity)
        {
             dbContext.Set<IEntity>().Update(entity);
        }
        public void Delete(IEntity entity)
        {
           dbContext.Set<IEntity>().Remove(entity);
        }

        public async Task<IEnumerable<IEntity>> GetAllAsync()
        {
           return  await  dbContext.Set<IEntity>().ToListAsync();
        }
    }
}
