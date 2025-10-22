using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayes.Specification
{
    public static class SpecificationEvaluator
    {
        //Create Query
        public static IQueryable<TEntity> CreateQuery<TEntity, TKey>(ISpecification<TEntity, TKey> specification, IQueryable<TEntity> _inputQuery) where TEntity : BaseOfAllContentEntities<TKey>
        {
            var query = _inputQuery;
            if (specification.Criteria is not null)
                query = query.Where(specification.Criteria);
            if (specification.OrderBy is not null)
            {
                query = query.OrderBy(specification.OrderBy);
            }
            if (specification.IsPaginated)
            {
                query = query.Skip(specification.Skip).Take(specification.Take);
            }

            if (specification.OrderByDesc is not null)
            {
                query = query.OrderByDescending(specification.OrderByDesc);
            }

            if (specification.IncludeExpressions.Any() && specification.IncludeExpressions is not null)
            {

                //foreach (var expression in specification.IncludeExpressions)
                //{
                //    query = query.Include(expression);
                //}
                query = specification.IncludeExpressions.Aggregate(query, (currentQuery, includeExpression) => currentQuery.Include(includeExpression));

            }
            return query;
        }



    }
}
