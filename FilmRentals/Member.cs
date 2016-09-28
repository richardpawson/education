
using NakedObjects;
using System.ComponentModel;

namespace FilmRentals
{ 
    public class Member
    {
        [Disabled, MemberOrder(0), DisplayName("Membership Number")]
        public virtual int MemberId { get; set; }

        [Title]//This property will be used for the object's title at the top of the view and in a link
        [MemberOrder(1)] //Determines the order in which (visible) properties are displayed on the UI
        public virtual string Name { get; set; }

        [MemberOrder(2)]
        public virtual string Address { get; set; }
    }

}
