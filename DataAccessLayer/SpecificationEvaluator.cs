using BusinessAccessLayes.Specification;
using DataAccessLayer.Models;
using DataAccessLayer.Models.Contents.Lessons;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
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
            if (typeof(TEntity) == typeof(Lesson))
                query = query.Cast<Lesson>()
                             .Include(l => l.course)
                             .ThenInclude(c => c.Level)
                             .Cast<TEntity>();

            return query;
        }



    }
}
