using System;
using System.Collections.Generic;
using System.IO;

namespace Grades
{
    public class GradeBook
    {
        private List<float> grades = new List<float>();

        public string Name
        {
            get
            {
                return _name;    
            }
            set
            {
                if(string.IsNullOrEmpty(value)){
                    throw new ArgumentException("Name cannot be null or empty");
                }
                
                if(_name != value && NameChanged != null)
                {
                    NameChangedEventArgs args = new NameChangedEventArgs();
                    args.ExistingName = _name;
                    args.NewName = value;
                    NameChanged(this, args);
                    _name = value;
                }

            }
        }

        public void WriteGrade(TextWriter destiniation)
        {
            for (int i = 0; i < grades.Count; i++)
            {
                destiniation.WriteLine(grades[i]);
            }
        }

        private string _name;

        // adding event keyword makes it onlly possible to += or -= but not =
        public event NameChangedDelegate NameChanged;

        public GradeBook()
        {
            _name = "Empty";    
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
