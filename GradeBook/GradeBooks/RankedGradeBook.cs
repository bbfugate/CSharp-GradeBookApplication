using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook

    {
        public RankedGradeBook(string name): base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count <5)
            {
                throw new InvalidOperationException("Ranked grading requires at least five student");
            }

            var threshold = (int)Math.Ceiling(Students.Count * .02);
            var grades = Students.OrderByDescending(x => x.AverageGrade).Select(x => x.AverageGrade).ToList();

            if (grades[threshold-1] <= averageGrade)
            {
                return 'A';
            }
            else if (grades[threshold - 2] <= averageGrade)
            {
                return 'B';
            }
            else if (grades[threshold - 3] <= averageGrade)
            {
                return 'C';
            }
            else if (grades[threshold - 4] <= averageGrade)
            {
                return 'D';
            }
            else 
            {
                return 'F';
            }


        }


    }
}
