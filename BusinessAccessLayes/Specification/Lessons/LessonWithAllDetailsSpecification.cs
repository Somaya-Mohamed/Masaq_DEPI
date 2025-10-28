using DataAccessLayer.Models.Contents.Lessons;
using Shared.DataTransferObjects.Lessons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayes.Specification.Lessons
{
    public class LessonWithAllDetailsSpecification : BaseSpecification<Lesson, int>
    {
        public LessonWithAllDetailsSpecification(LessonQueryParams queryParams):base(P=>((string.IsNullOrEmpty(queryParams.SearchValue) || P.Title.ToLower().Contains(queryParams.SearchValue.ToLower()))))
           
        {
            AddInclude(p => p.announcements);
            AddInclude(p => p.comments);
            AddInclude(p => p.course);
            AddInclude(p => p.LessonVideos);

            switch (queryParams.sortingOptions)
            {
                case LessonSortingOptions.NameAscending:
                    AddOrderBy(l => l.Title);
                    break;
                case LessonSortingOptions.NameDescending:
                    AddOrderByDesc(l => l.Title);
                    break;
                default:
                    AddOrderBy(l => l.Id);
                    break;
            }

            //ApplyPagination(queryParams.PageIndex, queryParams.PageSize);
        }
    }
}
