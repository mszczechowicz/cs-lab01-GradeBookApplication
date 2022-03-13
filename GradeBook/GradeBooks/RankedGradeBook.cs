using System;
using System.Collections.Generic;
using System.Text;
using GradeBook.Enums;
namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {

        public GradeBookType Type { get; set; }

        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }


        public override char GetLetterGrade(double averageGrade)
        {
            int students = Students.Count;
            try
            {
                if (Students.Count < 5)
                    throw new InvalidOperationException();
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            double x = 0;
            double N = students / 5;

            foreach (var student in Students)
            {
                if (averageGrade > student.AverageGrade)
                {
                    x++;
                }
            }

            if (x >= N * 4)
                return 'A';
            else if (x < N * 4 && x >= N * 3)
                return 'B';
            else if (x < N * 3 && x >= N * 2)
                return 'C';
            else if (x < N * 2 && x >= N)
                return 'D';
            else
                return 'F';
        }
        public override void CalculateStatistics()
        {

            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
            }
            else
            base.CalculateStatistics();
        }
        public override void CalculateStudentStatistics(string name)
        {

            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
            }
            else

                base.CalculateStudentStatistics(name);
        }
    }
}

