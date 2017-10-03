using System;
using System.IO;

namespace Grades
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            GradeBook book = new GradeBook();

            book.NameChanged += new NameChangedDelegate(OnNameChanged);
            AddGrades(book);
            SaveGrades(book);
            WriteResults(book);
        }

        private static void WriteResults(GradeBook book)
        {
            GradeStatistics stats = book.ComputeStatistics();
            // Console.WriteLine(stats.AverageGrade);
            // Console.WriteLine(stats.HighestGrade);
            // Console.WriteLine(stats.LowestGrade);
            // book.Name = "John's Grade Book";

            // book.NameChanged += new NameChangedDelegate(OnNameChanged2);
            // book.NameChanged += OnNameChanged2;

            // book.Name = "Grade Book";
            // book.Name = null;
            GetBookName(book);

            WriteResult("Average", stats.AverageGrade);
            WriteResult("Highest", (int)stats.HighestGrade);
            WriteResult("Lowest", stats.LowestGrade);
            WriteResult(stats.Description, stats.LetterGrade);
        }

        private static void SaveGrades(GradeBook book)
        {
			// using statement makes sure unmanaged resource is properly delt with
			// similar to wrapping in try catch with Close / Dispose in finally block
			// usually available on objects that have a Dispose method
			using (StreamWriter outputFile = File.CreateText("grades.txt"))
            {
                book.WriteGrade(outputFile); // Console.Out
                                             // outputFile.Close();
            }
        }

        private static void AddGrades(GradeBook book)
        {
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);
        }

        private static void GetBookName(GradeBook book)
        {
            try
            {
                Console.WriteLine("Enter name for book");
                book.Name = Console.ReadLine();
                //Console.WriteLine(book.Name);  
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                book.Name = "Untitled";
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void WriteResult(string description, float result)
        {
            Console.WriteLine(description + ": " + result);
        }

		static void WriteResult(string description, int result)
		{
            Console.WriteLine("{0}: {1}", description, result);
		}

		static void WriteResult(string description, string result)
		{
			Console.WriteLine(description + ": " + result);
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
