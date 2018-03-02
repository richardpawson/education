using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Academy.DataBase;
using Academy.Model;

namespace Academy.SeedData
{
    public class ExampleDbInitializer : DropCreateDatabaseIfModelChanges<ExampleDbContext>
    {
        private ExampleDbContext Context;
        protected override void Seed(ExampleDbContext context)
        {
            this.Context = context;
            AddNewStudent("Alie Algol");
            AddNewStudent("Forrest Fortran");
            AddNewStudent("James Java");
        }

        private void AddNewStudent(string name)
        {
            var st = new Student() { FullName = name };
            Context.Students.Add(st);
        }
    }
}
