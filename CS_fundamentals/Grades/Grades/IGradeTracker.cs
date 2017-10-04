using System.IO;

namespace Grades
{
    internal interface IGradeTracker
    {
	    void AddGrade(float grade);
		GradeStatistics ComputeStatistics();
		void WriteGrades(TextWriter destiniation);
        string Name { get; set; }
        event NameChangedDelegate NameChanged;
    }
}