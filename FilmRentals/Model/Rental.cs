using NakedObjects;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace FilmRentals.Model
{
    public class Rental
    {
        #region Injected Services 
        public MemberRepository MemberRepository { set; protected get; }
        public FilmRepository FilmRepository { set; protected get; }
        public IDomainObjectContainer Container { set; protected get; }
        #endregion

        #region Properties & Collections
        [Disabled, DisplayName("Rental number"), Title]
        public virtual int RentalId { get; set; }

        [MemberOrder(1)]
        public virtual Member Member { get; set; }

        [PageSize(10)]
        public IQueryable<Member> AutoCompleteMember([MinLength(3)] string matching)
        {
            return MemberRepository.FindMemberByNameOrNumber(matching);
        }

        [MemberOrder(2)]
        public virtual Film Film { get; set; }

        [PageSize(10)]
        public IQueryable<Film> AutoCompleteFilm([MinLength(3)] string matching)
        {
            return FilmRepository.FindFilmByTitle(matching);
        }

        [MemberOrder(3)]
        [Mask("d")]
        public virtual DateTime DateOut { get; set; }

        [MemberOrder(4)]
        public virtual int DaysRented { get; set; }

        [MemberOrder(5)]
        [Mask("d")]
        public virtual DateTime DateBack { get; set; }

        [MemberOrder(6)]
        [Disabled]
        public virtual bool Returned { get; set; }
        #endregion

        #region Actions
        public void MarkAsReturned()
        {
            Returned = true;
        }
        #endregion
    }
}