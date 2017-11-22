using System;
namespace StudentObjects
{

public class Student
{
        public Student(int number, string first, string last, DateTime dob)
        {
            Number = number;
            FirstName = first;
            LastName = last;
            DateOfBirth = dob;
        }

    //It is better practice to use the 'property' syntax for all public data
    public int Number { get; set; }

    //Use the 'prop' snippet to create a property
    public string FirstName { get; set; }
    
    //'get' and 'set' mean the property can be read, and written
    public string LastName { get; set; }
    
    //Making the 'set' private means that external code cannot change the value
    public DateTime DateOfBirth { get; private set; }

    public char Grade { get; set; }
}
    
}
