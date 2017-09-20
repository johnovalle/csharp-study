using System;

namespace Hello
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter your name");
            string userName = Console.ReadLine();

            Console.WriteLine("How many hours of sleep did you get last night?:");
            int hoursOfSleep = int.Parse(Console.ReadLine());

            if(hoursOfSleep > 7)
            {
                Console.WriteLine("Well rested aren't you " + userName +"?");
            }
            else
            {
                Console.WriteLine("Go get some rest " + userName);
            }

            //Console.WriteLine("Hello " + userName);

        }
    }
}