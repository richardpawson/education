using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Academy.DataBase;
using Academy.Model;

namespace Academy.ExampleData
{
    public class AcademyDbInitializer : DropCreateDatabaseAlways<AcademyDbContext>
    {
        private AcademyDbContext Context;
        protected override void Seed(AcademyDbContext context)
        {
            Context = context;
            #region  Teachers
            var br = CreateNewTeacher("Mr. Deckerd");
            var dt = CreateNewTeacher("Dr. Tyrell");
            var mm = CreateNewTeacher("Maj. Major");
            var md = CreateNewTeacher("Mrs. Doubtfire");
            var dd = CreateNewTeacher("Dr. Doolittle");
            var ds = CreateNewTeacher("Dr. Strangelove");
            var mi = CreateNewTeacher("Ms. Issippi");
            var ma = CreateNewTeacher("Ms. Andrist");
            var dj = CreateNewTeacher("Dr. Jekyll");
            var mh = CreateNewTeacher("Mr. Hyde");
            var mr = CreateNewTeacher("Mrs. Robinson");
            var mw = CreateNewTeacher("Mrs. Worthington");
            var dh = CreateNewTeacher("Dr. Hu");
            var co = CreateNewTeacher("Cpt. Over");
            #endregion
            #region Students
            var aa = CreateNewStudent("Alie Algol", 12);
            var ff = CreateNewStudent("Forrest Fortran", 12);
            var jj = CreateNewStudent("James Java", 12);
            var cc = CreateNewStudent("Celia Cee-Sharp", 12);
            var vv = CreateNewStudent("Veronica Vee-Bee", 13);
            var ss = CreateNewStudent("Simon SmallTalk", 13);
            var tt = CreateNewStudent("Tilly TypeScript", 13);
            var pp = CreateNewStudent("Petra Python", 11);
            var hh = CreateNewStudent("Harry Haskell", 10);
            var cb = CreateNewStudent("Corinie Cobol", 11);
            #endregion
            #region Subjects
            var csc = CreateNewSubject("Computer Science");
            var math = CreateNewSubject("Maths");
            var eng = CreateNewSubject("English");
            var phy = CreateNewSubject("Physics");
            var chem = CreateNewSubject("Chemistry");
            var bio = CreateNewSubject("Biology");
            var his = CreateNewSubject("History");
            var fre = CreateNewSubject("French");
            var ger = CreateNewSubject("German");
            var dra = CreateNewSubject("Drama");
            var des = CreateNewSubject("Design & Technology");
            var film = CreateNewSubject("Film Studies");
            var geo = CreateNewSubject("Geography");
            #endregion
            #region Sets
            var CS12 = CreateNewSet("CS12", csc, 12, ds);
            var CS13 = CreateNewSet("CS13", csc, 13, ds);
            var MA09_1 = CreateNewSet("MA09_1", math, 9, ma);
            var MA10_1 = CreateNewSet("MA10_1", math, 10, ma);
            var MA11_1 = CreateNewSet("MA11_1", math, 11, ma);
            var MA09_2 = CreateNewSet("MA09_2", math, 9, dj);
            var MA10_2 = CreateNewSet("MA10_2", math, 10, dj);
            var MA11_2 = CreateNewSet("MA11_2", math, 11, dj);
            #endregion
            #region Make up sets
            AssignStudents(CS12, aa,cc, ff);
            AssignStudents(CS13, vv, ss);
            #endregion
        }

        private Teacher CreateNewTeacher(string name)
        {
            var obj = new Teacher() { FullName = name };
            Context.Teachers.Add(obj);
            Context.SaveChanges();
            return obj;
        }

        private Student CreateNewStudent(string name, int year)
        {
            var st = new Student() { FullName = name, CurrentYearGroup = year };
            Context.Students.Add(st);
            Context.SaveChanges();
            return st;
        }

        private Subject CreateNewSubject(string name)
        {
            var obj = new Subject() { Name = name};
            Context.Subjects.Add(obj);
            Context.SaveChanges();
            return obj;
        }

        private Set CreateNewSet(string name, Subject subject, int yearGroup, Teacher teacher)
        {
            var obj = new Set() { SetName = name, Subject = subject, YearGroup = yearGroup, Teacher = teacher };
            Context.Sets.Add(obj);
            Context.SaveChanges();
            return obj;
        }

        private SubjectReport CreateNewSubjectReport(Student st, Subject sub, Grades grade, Teacher teach, DateTime date)
        {
            var obj = new SubjectReport() { Student = st, Subject = sub, Grade = grade, GivenBy = teach, Date = date };
            Context.SubjectReports.Add(obj);
            Context.SaveChanges();
            return obj;
        }

        private void AssignStudents(Set set, params Student[] students)
        {
            foreach (Student stu in students)
            {
                set.Students.Add(stu);
            }
            Context.SaveChanges();
        }

    }
}
