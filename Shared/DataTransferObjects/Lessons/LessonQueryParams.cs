using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.Lessons
{
    public class LessonQueryParams
    {
      
        public LessonSortingOptions sortingOptions { get; set; }

        public string? SearchValue { get; set; }
        //public int PageIndex { get; set; } = 1;

        //private const int DefaultPageSize = 5;

        //private const int MaxPageSize = 10;

        //public int _pageSize = DefaultPageSize;
        //public int PageSize
        //{
        //    get { return _pageSize; }
        //    set { _pageSize = (value > MaxPageSize) ? MaxPageSize : value; }
        //}




    }
}
