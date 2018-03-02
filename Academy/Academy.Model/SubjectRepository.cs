using NakedObjects;
using System.Linq;

namespace Academy.Model
{
    public class SubjectRepository
    {
        #region Injected Services
        //An implementation of this interface is injected automatically by the framework
        public IDomainObjectContainer Container { set; protected get; }
        #endregion
        public Subject CreateNewSubject()
        {
            return Container.NewTransientInstance<Subject>();
        }

        public IQueryable<Subject> AllSubjects()
        {
            return Container.Instances<Subject>();
        }

        public IQueryable<Subject> FindSubjectByName(string name)
        {
            return AllSubjects().Where(c => c.Name.ToUpper().Contains(name.ToUpper()));
        }
    }
}
