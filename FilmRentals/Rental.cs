using NakedObjects;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace FilmRentals
{
    public class Rental
    {
        #region Injected Services 
        public MemberRepository MemberRepository { set; protected get; }
        public FilmRepository FilmRepository { set; protected get; }
        
        public IDomainObjectContainer Container { set; protected get; }
        #endregion

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
        [Mask("d")] //Formats field as a readable date with no time element
        public virtual DateTime DateOut { get; set; }

        [MemberOrder(4)]
        [Mask("d")]
        public virtual DateTime DateBack { get; set; }

    }
}