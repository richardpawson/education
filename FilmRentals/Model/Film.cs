using NakedObjects;


namespace FilmRentals.Model
{
    public class Film
    {
         public virtual PriceCodes PriceCode { get; set; }
        [NakedObjectsIgnore]
        public virtual int FilmId { get; set; }

        [MemberOrder(1), Title]
        public virtual string Title { get; set; }

        [MemberOrder(2)]
        public virtual Rating Rating { get; set; }

    }
}