using System;
using System.Collections.Generic;
namespace Grades
{
    public class GradeBook
    {
        private List<float> grades = new List<float>();

        public GradeBook()
        {
            
        }
        public void AddGrade(float grade) 
        {
            grades.Add(grade);
        }

        public GradeStatistics ComputeStatistics()
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
