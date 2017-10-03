using System;
namespace Grades
{
    public class GradeStatistics
    {
        public float AverageGrade;
        public float HighestGrade;
        public float LowestGrade;

        public GradeStatistics()
        {
            HighestGrade = 0;
            LowestGrade = float.MaxValue;
        }

        public string Description
        {
            get
            {
                string result;
                switch(LetterGrade)
                {
                    case "A":
                        result = "Amazing!";
                        break;
                    case "B":
                        result = "Good job";
                        break;
					case "C":
						result = "Fair";
						break;
					case "D":
						result = "Below average";
						break;
                    default:
                        result = "Try harder";
                        break;
                }
                return result;
            }
        }
        // if there is only a get the property is read-only
        public string LetterGrade
        {
            get
            {
                string result;
                if (AverageGrade >= 90)
                {
                    result = "A";
                }
                else if (AverageGrade >= 80)
                {
                    result = "B";
                }
                else if (AverageGrade >= 70)
                {
                    result = "C";
                }
                else if (AverageGrade >= 65)
                {
                    result = "D";
                }
                else
                {
                    result = "F";
                }
                return result;
            }
        }
    }
}
