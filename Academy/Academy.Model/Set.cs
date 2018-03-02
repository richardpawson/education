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
        // This region should contain properties to hold references to any services required by the
        // object.  Use the 'injs' shortcut to add a new service; 'injc' to add an injected Container

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



    }
}

