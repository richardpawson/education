using NakedObjects;
using System.Linq;


namespace FilmRentals
{
    public class RatingRepository
    {
        #region Injected Services
        //An implementation of this interface is injected automatically by the framework
        public IDomainObjectContainer Container { set; protected get; }
        #endregion
        public Rating CreateNewRating()
        {
            return Container.NewTransientInstance<Rating>();
        }

        public IQueryable<Rating> AllRatings()
        {
            return Container.Instances<Rating>();
        }

    }

}
