using System;

namespace Grades
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            GradeBook book = new GradeBook();

            book.NameChanged += new NameChangedDelegate(OnNameChanged);

            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);

            GradeStatistics stats = book.ComputeStatistics();
            // Console.WriteLine(stats.AverageGrade);
            // Console.WriteLine(stats.HighestGrade);
            // Console.WriteLine(stats.LowestGrade);
            book.Name = "John's Grade Book";

            book.NameChanged += new NameChangedDelegate(OnNameChanged2);
            book.NameChanged += OnNameChanged2;

            book.Name = "Grade Book";
            book.Name = null;
            Console.WriteLine(book.Name);
            WriteResult("Average", stats.AverageGrade);
            WriteResult("Highest", (int)stats.HighestGrade);
            WriteResult("Lowest", stats.LowestGrade);
        }
        static void WriteResult(string description, float result)
        {
            Console.WriteLine(description + ": " + result);
        }

		static void WriteResult(string description, int result)
		{
            Console.WriteLine("{0}: {1}", description, result);
		}

        static void OnNameChanged(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine($"Grade book chaning name from {args.ExistingName} to {args.NewName}");
        }

        static void OnNameChanged2(object sender, NameChangedEventArgs args)
        {
			Console.WriteLine("***");
		}
    }
}
