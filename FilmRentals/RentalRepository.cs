using NakedObjects;
using System.Linq;


namespace FilmRentals
{
    public class RentalRepository
    {
        #region Injected Services
        //An implementation of this interface is injected automatically by the framework
        public IDomainObjectContainer Container { set; protected get; }
        #endregion
        public Rental CreateNewRental()
        {
            return Container.NewTransientInstance<Rental>();
        }

        public IQueryable<Rental> AllRentals()
        {
            return Container.Instances<Rental>();
        }

    }

}
