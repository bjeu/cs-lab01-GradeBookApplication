using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if(Students.Count < 5) throw new InvalidOperationException();

            int top20 = (int)Math.Ceiling(0.2 * Students.Count);
            List<double> oceny = new List<double>();

            List<Student> _Students = new List<Student>(Students);
            _Students.Sort((y, x) => x.AverageGrade.CompareTo(y.AverageGrade));

            foreach (Student ocena in _Students)
            {
                oceny.Add(ocena.AverageGrade);
            }

            if(oceny[top20] < averageGrade) return 'A';
            else if(oceny[(2 * top20)] < averageGrade) return 'B';
            else if(oceny[(3 * top20)] < averageGrade) return 'C';
            else if(oceny[(4 * top20)] < averageGrade) return 'D';
            else return 'F';
        }
        public override void CalculateStatistics()
        {
            if(Students.Count < 5) Console.WriteLine("Ranked grading requires at least 5 students.");
            else base.CalculateStatistics();
        }
        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5) Console.WriteLine("Ranked grading requires at least 5 students.");
            else base.CalculateStudentStatistics(name);
        }
    }
}
