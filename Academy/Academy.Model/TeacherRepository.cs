using NakedObjects;
using System.Linq;

namespace Academy.Model
{
    public class TeacherRepository
    {
        #region Injected Services
        //An implementation of this interface is injected automatically by the framework
        public IDomainObjectContainer Container { set; protected get; }
        #endregion
        public Teacher CreateNewTeacher()
        {
            return Container.NewTransientInstance<Teacher>();
        }

        public IQueryable<Teacher> AllTeachers()
        {
            return Container.Instances<Teacher>();
        }

        public IQueryable<Teacher> FindTeacherByName(string name)
        {
            return AllTeachers().Where(c => c.FullName.ToUpper().Contains(name.ToUpper()));
        }
    }

}
