using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using NakedObjects;

namespace Academy.Model
{
    public class Set
    {
        #region Injected Services
        public IDomainObjectContainer Container { set; protected get; }
        #endregion
        #region Life Cycle Methods
        // This region should contain any of the 'life cycle' convention methods (such as
        // Created(), Persisted() etc) called by the framework at specified stages in the lifecycle.


        #endregion

        [NakedObjectsIgnore]
        public virtual int Id { get; set; }


        [MemberOrder(1), Title]
        public virtual string SetName { get; set; }

        [MemberOrder(2)]
        public virtual Subject Subject { get; set; }

        [MemberOrder(3), Range(9,13)]
        public virtual int YearGroup { get; set; }

        [MemberOrder(4)]
        public virtual Teacher Teacher { get; set; }

        private ICollection<Student> _students = new List<Student>();

        [Eagerly(EagerlyAttribute.Do.Rendering)]
        [TableView(false, "FullName")]
        [MemberOrder(5)]
        public virtual ICollection<Student> Students
        {
            get
            {
                return _students;
            }
            set
            {
                _students = value;
            }
        }

        public void AddStudentToSet(Student student)
        {
            Students.Add(student);
        }

        public void RemoveStudentFromSet(Student student)
        {
            Students.Remove(student);
        }

        public IList<Student> Choices0RemoveStudentFromSet()
        {
            return Students.ToList();
        }

        public void TransferStudentTo(Student student, Set newSet)
        {
            this.RemoveStudentFromSet(student);
            newSet.AddStudentToSet(student);
        }

        public IList<Student> Choices0TransferStudentTo()
        {
            return Students.ToList();
        }

        [PageSize(10)]
        public IList<Set> Choices1TransferStudentTo()
        {
            int subjId = this.Subject.Id;
            int yg = this.YearGroup;
            return Container.Instances<Set>().Where(s => s.Subject.Id == subjId && s.YearGroup == yg).ToList();
        }
    }
}

