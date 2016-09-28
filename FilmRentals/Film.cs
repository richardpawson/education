using NakedObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FilmRentals
{
    public class Film
    {
        [NakedObjectsIgnore]
        public virtual int FilmId { get; set; }

        [MemberOrder(1), Title]
        public virtual string Title { get; set; }

        [MemberOrder(2)]
        public virtual Rating Rating { get; set; }

        [Mask("c")] //Renders the decimal field with a currency symbol and with 2 decimal places
        [MemberOrder(3)]
        public virtual decimal Cost { get; set; }
    }
}