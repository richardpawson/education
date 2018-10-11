using System;

namespace IntroToLINQ
{
    public class Student
    {
        public int StudentID { get; set; }
        public string FullName { get; set; }
        public Sex Sex { get; set; }
        public int GCSEGrade { get; set; }

        public Student(string name, int id, Sex sx, int grade)
        {
            StudentID = id;
            FullName = name;
            Sex = sx;
            GCSEGrade = grade;
        }

        public Student()
        {

        }

        public string Summary()
        {
            return StudentID + " " + FullName;
        }

    }

    public enum Sex
    {
        Male,Female
    }


}
