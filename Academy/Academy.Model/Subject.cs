using NakedObjects;

namespace Academy.Model
{
    [Bounded]
    public class Subject : IPrivateData
    {
        #region Injected Services

        public IDomainObjectContainer Container { set; protected get; }

        #endregion
        #region LifeCycle methods
        public void Persisting()
        {
            CreatedBy = Container.Principal.Identity.Name;
        }
        #endregion

        [NakedObjectsIgnore]
        public virtual int Id { get; set; }

        [MemberOrder(1), Title]
        public virtual string Name { get; set; }


        [MemberOrder(99), Disabled]
        public virtual string CreatedBy { get; set; }
    }
}
