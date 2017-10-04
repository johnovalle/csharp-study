using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Grades
{
    public class GradeBook : GradeTracker
    {
        protected List<float> grades = new List<float>();

        public override IEnumerator GetEnumerator()
        {
            return grades.GetEnumerator();
        }

        public override void WriteGrades(TextWriter destiniation)
        {
            for (int i = 0; i < grades.Count; i++)
            {
                destiniation.WriteLine(grades[i]);
            }
        }





        public GradeBook()
        {
            _name = "Empty";    
        }

        public override void AddGrade(float grade) 
        {
            grades.Add(grade);
        }

        public override GradeStatistics ComputeStatistics()
        {
            GradeStatistics stats = new GradeStatistics();

            float sum = 0;
            foreach (float grade in grades)
            {
                //if(grade > stats.HighestGrade)
                //{
                //    stats.HighestGrade = grade;
                //}
                stats.HighestGrade = Math.Max(stats.HighestGrade, grade);
                //if(grade < stats.LowestGrade)
                //{
                //    stats.LowestGrade = grade;
                //}
                stats.LowestGrade = Math.Min(stats.LowestGrade, grade);
                sum += grade;
            }

            stats.AverageGrade = sum / grades.Count;

            return stats;
        }





    }
}
