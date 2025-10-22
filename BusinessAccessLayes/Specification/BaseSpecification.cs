using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayes.Specification
{
    public abstract class BaseSpecification<IEntity, IKey> : ISpecification<IEntity, IKey> where IEntity : BaseOfAllContentEntities<IKey>
    {
        protected BaseSpecification(Expression<Func<IEntity, bool>>? _criteria)
        {


            Criteria = _criteria;
        }
        public Expression<Func<IEntity, bool>>? Criteria { get; private set; }

        #region Include
        public List<Expression<Func<IEntity, object>>> IncludeExpressions { get; } = new List<Expression<Func<IEntity, object>>>();
        protected void AddInclude(Expression<Func<IEntity, object>> IncludeExpression)
        {
            IncludeExpressions.Add(IncludeExpression);
        }
        #endregion

        #region Sorting
        public Expression<Func<IEntity, object>>? OrderBy { get; private set; }

        public Expression<Func<IEntity, object>>? OrderByDesc { get; private set; }

        protected void AddOrderBy(Expression<Func<IEntity, object>> orderByExp)

        {
            OrderBy = orderByExp;

        }
        protected void AddOrderByDesc(Expression<Func<IEntity, object>> orderByDescExp)
        {
            OrderByDesc = orderByDescExp;

        }
        #endregion

        #region Pagination

        public int Skip { get; private set; }

        public int Take { get; private set; }

        public bool IsPaginated { get; set; }

        protected void ApplyPagination(int _pageSize, int _pageIndex)
        {
            Take = _pageSize;
            Skip = (_pageIndex - 1) * _pageSize;
            IsPaginated = true;
        }
        #endregion
    }
}
