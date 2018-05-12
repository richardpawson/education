
using NakedObjects;
using System.Collections.Generic;

namespace Quadrivia
{

    //A set or class, or any grouping of Students managed by a teacher
    public class Set
    {
        #region Injected Services

        #endregion

        #region Properties

        [NakedObjectsIgnore]
        public virtual int Id { get; set; }

        [MemberOrder(1), Title]
        public virtual string Name { get; set; }

        [MemberOrder(1)]
        public virtual Teacher Teacher { get; set; }

        [MemberOrder(1)]
        public virtual Subject Subject { get; set; }

        [MemberOrder(1)] //Range e.g. 7-13
        public virtual int YearGroup { get; set; }

        [MemberOrder(1)]
        public virtual ICollection<Student> Students { get; set; } = new List<Student>();
        #endregion

        #region Actions
        public void CreateStudents() { }
        public void AddExistingStudents() { }
        public void RemoveStudents() { }
        public void TransferStudents() { }
        #endregion
    }
}
