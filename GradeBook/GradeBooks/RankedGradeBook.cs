using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if(Students.Count < 5) { throw new InvalidOperationException(); }
            int avgGradeCount = 0;
            int students20 = (int)(Students.Count * 0.2f);

            foreach (var student in Students)
            {
                if (student.AverageGrade > averageGrade)
                {
                    avgGradeCount++;
                }
            }

            if (avgGradeCount < students20) return 'A';
            else if (avgGradeCount < 2 * students20) return 'B';
            else if (avgGradeCount < 3 * students20) return 'C';
            else if (avgGradeCount < 4 * students20) return 'D';
            else return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5) { Console.WriteLine("Ranked grading requires at least 5 students."); }
            else base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5) { Console.WriteLine("Ranked grading requires at least 5 students."); }
            else base.CalculateStudentStatistics(name);
        }

    }
}
