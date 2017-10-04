using System;
using System.IO;

namespace Grades
{
    public abstract class GradeTracker
    {
        public abstract void AddGrade(float grade);
        public abstract GradeStatistics ComputeStatistics();
        public abstract void WriteGrades(TextWriter destiniation);

        protected string _name;
		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					throw new ArgumentException("Name cannot be null or empty");
				}

				if (_name != value && NameChanged != null)
				{
					NameChangedEventArgs args = new NameChangedEventArgs();
					args.ExistingName = _name;
					args.NewName = value;
					NameChanged(this, args);
					_name = value;
				}

			}
		}
		// adding event keyword makes it onlly possible to += or -= but not =
		public event NameChangedDelegate NameChanged;
    }
}
