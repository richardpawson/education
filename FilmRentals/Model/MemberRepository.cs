using NakedObjects;
using System.Linq;


namespace FilmRentals.Model
{
    public class MemberRepository
    {
        #region Injected Services
        //An implementation of this interface is injected automatically by the framework
        public IDomainObjectContainer Container { set; protected get; }
        #endregion
        public Member CreateNewMember()
        {
            return Container.NewTransientInstance<Member>();
        }

        public IQueryable<Member> AllMembers()
        {
            return Container.Instances<Member>();
        }

        public IQueryable<Member> FindMemberByNameOrNumber(string matching)
        {
            return AllMembers().Where(c => c.Name.ToUpper().Contains(matching.ToUpper()) ||
                    c.MemberId.ToString() == matching);
        }
    }
}
