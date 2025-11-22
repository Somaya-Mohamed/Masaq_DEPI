using DataAccessLayer.Models.Contents.Exams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayes.Specification.ExamSpc
{
    public class ExamByIdSpecification: BaseSpecification<Exam, int>
    {
        public ExamByIdSpecification(int id)
          : base(c => c.Id == id)
        {
            AddInclude(c => c.questions);


        }
    }
}
