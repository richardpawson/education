using NakedObjects;
using System.Linq;


namespace FilmRentals.Model
{
    public class FilmRepository
    {
        #region Injected Services
        //An implementation of this interface is injected automatically by the framework
        public IDomainObjectContainer Container { set; protected get; }
        #endregion
        public Film CreateNewFilm()
        {
            return Container.NewTransientInstance<Film>();
        }

        public IQueryable<Film> AllFilms()
        {
            return Container.Instances<Film>();
        }

        public IQueryable<Film> FindFilmByTitle(string name)
        {
            return AllFilms().Where(c => c.Title.ToUpper().Contains(name.ToUpper()));
        }

    }

}
