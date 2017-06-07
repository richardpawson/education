namespace PolymorphicSorting
{
    public class Student
    {
        public Student(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
