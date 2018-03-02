using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Academy.DataBase;
using Academy.Model;

namespace Academy.SeedData
{
    public class AcademyDbInitializer : DropCreateDatabaseIfModelChanges<AcademyDbContext>
    {
        private AcademyDbContext Context;
        protected override void Seed(AcademyDbContext context)
        {
            this.Context = context;
            AddNewStudent("Alie Algol", 9);
            AddNewStudent("Forrest Fortran", 9);
            AddNewStudent("James Java", 9);
        }

        private void AddNewStudent(string name, int year)
        {
            var st = new Student() { FullName = name, CurrentYearGroup = year };
            Context.Students.Add(st);
        }
    }
}
