using NakedObjects;

namespace FilmRentals.Model
{
    [Bounded] //Indicates that all instances may be displayed as a 
    //drop-down list on an input field of this type

    public class Rating
    {
        [NakedObjectsIgnore]
        public virtual int RatingId { get; set; }

        [MemberOrder(1)]
        [Title]
        public virtual string Description { get; set; }

        [MemberOrder(2)]
        public virtual int Age { get; set; }
     }
}