using System;

namespace IntroToLINQ
{
    public class Student
    {
        public int StudentID { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PredictedGrade { get; set; }

        public Student(string name, int id, DateTime dob, string grade)
        {
            StudentID = id;
            FullName = name;
            DateOfBirth = dob;
            PredictedGrade = grade;
        }

        public Student()
        {

        }

        public string Summary()
        {
            return FullName + " " + StudentID + " " + DateOfBirth + " " + PredictedGrade;
        }

    }
}
