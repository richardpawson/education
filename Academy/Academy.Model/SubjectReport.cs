using NakedObjects;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Academy.Model
{
    public class SubjectReport 
    {
        #region Injected Services
        public IDomainObjectContainer Container { set; protected get; }

        public StudentRepository Students { set; protected get; }

        public TeacherRepository Teachers { set; protected get; }
        #endregion

        [NakedObjectsIgnore]
        public virtual int Id { get; set; }

        [MemberOrder(1), Disabled]
        public virtual Student Student { get; set; }

        [PageSize(10)]
        public IQueryable<Student> AutoCompleteStudent([MinLength(2)] string matching)
        {
            return Students.FindStudentByName(matching);
        }

        [MemberOrder(2), Disabled]
        public virtual Subject Subject { get; set; }

        [MemberOrder(3)]
        public virtual Grades Grade { get; set; }


        [MemberOrder(4)]
        public virtual Teacher GivenBy { get; set; }
        [PageSize(10)]
        public IQueryable<Teacher> AutoCompleteGivenBy([MinLength(2)] string matching)
        {
            return Teachers.FindTeacherByName(matching);
        }

        [MemberOrder(5)]
        [Mask("d")]
        public virtual DateTime Date { get; set; }

        public DateTime DefaultDate()
        {
            return DateTime.Today;
        }

        [MemberOrder(6)]
        [MultiLine][Optionally]
        public virtual string Notes { get; set; }
    }

    public enum Grades
    {
        A_star,A,B,C,D,E,U
    }
}
