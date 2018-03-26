using NakedObjects;
using System.Collections.Generic;
using System.Linq;

namespace Academy.Model
{
    public class Teacher
    {
        #region Injected Services

        public IDomainObjectContainer Container { set; protected get; }

        #endregion

        [NakedObjectsIgnore]
        public virtual int Id { get; set; }

        [Title][MemberOrder(1)]
        public virtual string FullName { get; set; }

        [MemberOrder(5)]
        [Eagerly(EagerlyAttribute.Do.Rendering)]
        [TableView(false,"Subject", "YearGroup", "SetName")]
        public virtual ICollection<Set> SetsTaught()
        {
            int id = this.Id;
            return Container.Instances<Set>().Where(s => s.Teacher.Id == id).OrderBy(s => s.Subject.Name).ThenBy(s => s.YearGroup).ToList();
        }
    }
}
