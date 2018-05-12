using NakedObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quadrivia
{


    [DescribedAs("A student potentially taking tests.This data is created and managed solely by the teacher  -  not directly by the student.")]
    public class Student
    {
        #region Properties
        [NakedObjectsIgnore]
        public virtual int Id { get; set; }

        [MemberOrder(1)]
        [DescribedAs("Only has to be meaningful to the teacher, and recognisable by student themselves, in the context of a set e.g. ‘Richard P’, or Richard 1’")]
        public virtual string Identifier { get; set; }

        [MemberOrder(1)]
        public virtual string PrimaryEmail { get; set; }

        [MemberOrder(1)]
        public virtual string LoginId { get; set; }

        [MemberOrder(1)]
        public virtual ICollection<Set> Sets { get; set; } = new List<Set>();

        [MemberOrder(1)]
        public virtual ICollection<TestAssignment> ActiveTests { get; set; } = new List<TestAssignment>();
        #endregion

        #region Actions
        public void ShowLoginHistory() { }

        public void AssociateLogin() { }

        public void DissociateLogin() { }

        public void ShowTestResults() { }

        public void ChangeIdentifier() { } //Audit records the fact of the  change, not the previous value
        #endregion
    }
}
