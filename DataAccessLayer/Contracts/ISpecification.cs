using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayes.Specification
{
    public interface ISpecification<IEntity, TKey> where IEntity : BaseOfAllContentEntities<TKey>
    {
        public Expression<Func<IEntity, bool>>? Criteria { get; }//where condition
        List<Expression<Func<IEntity, object>>> IncludeExpressions { get; }//which data include
        public Expression<Func<IEntity, object>>? OrderBy { get; }//order by asc
        public Expression<Func<IEntity, object>>? OrderByDesc { get; } //order by desc  

        public int Skip { get; }
        public int Take { get; }
        public bool IsPaginated { get; }

    }
}
