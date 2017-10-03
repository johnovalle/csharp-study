using System;
using NUnit.Framework;

namespace Grades.Tests.Types
{
    [TestFixture()]
    public class TypeTests
    {
        // Arrays are of a fixed size
        // Lists will autoexpand
        [Test]
        public void UsingArrays()
        {
            float[] grades;
            grades = new float[3];

            AddGrades(grades);
            Assert.AreEqual(89.1f, grades[1]);
        }

        private void AddGrades(float[] grades)
        {
            grades[1] = 89.1f;
        }

        // Date and String are immutable types
        // Methods do not modify to original value 
        // but return a new modified value
        [Test]
        public void UppercaseString()
        {
            string name = "john";
            name.ToUpper();

            Assert.AreNotEqual("JOHN", name);
        }

        [Test]
        public void AddDaysToDateTime()
        {
            DateTime date = new DateTime(2015, 1, 1);
            date.AddDays(1);
            //date = date.AddDays(1);

            Assert.AreNotEqual(2, date.Day);
        }
        // ref and out can change this behavior
        [Test]
        public void ValueTypesPassedByValue()
        {
            int x = 46;
            IncrementNumber(x);

            Assert.AreNotEqual(47, x);
        }

        private void IncrementNumber(int num)
        {
            num++;
        }

        [Test]
        public void ReferenceTypesPassByValue()
        {
            GradeBook book1 = new GradeBook();
            GradeBook book2 = book1;

            GiveBookAName(book2, "John's Book");

            Assert.AreEqual("John's Book", book1.Name);
        }

        private void GiveBookAName(GradeBook book, string name)
        {
            book.Name = name;
        }

        [Test]
        public void StringComparisons()
        {
            string name1 = "John";
            string name2 = "john";

            bool result = String.Equals(name1, name2, StringComparison.InvariantCultureIgnoreCase);
            Assert.IsTrue(result);
        }

        [Test]
        public void IntVariablesHoldAValue()
        {
            int x1 = 100;
            int x2 = x1;

            x1 = 4;
            Assert.AreNotEqual(x1, x2);
        }

        [Test]
        public void GradeBookVariablesHoldAReference()
        {
            GradeBook g1 = new GradeBook();
            GradeBook g2 = g1;

            g1.Name = "John's grade book";
            Assert.AreEqual(g1.Name, g2.Name);
        }
    }
}
