﻿using NakedObjects;

namespace FilmRentals
{
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