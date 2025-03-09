using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            //return base.GetLetterGrade(averageGrade);
            if (Students.Count < 5) 
            { 
                throw new InvalidOperationException("Ranked grading requires at least 5 students.");
            }


        }

    }
}
