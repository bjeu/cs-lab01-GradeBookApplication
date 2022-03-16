using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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

            Students.Sort((y, x) => x.AverageGrade.CompareTo(y.AverageGrade));

            foreach (Student ocena in Students)
            {
                oceny.Add(ocena.AverageGrade);
            }

            if(oceny[top20] < averageGrade) return 'A';
            else if(oceny[(2 * top20)] < averageGrade) return 'B';
            else if(oceny[(3 * top20)] < averageGrade) return 'C';
            else if(oceny[(4 * top20)] < averageGrade) return 'D';
            else return 'F';
        }
    }
}
