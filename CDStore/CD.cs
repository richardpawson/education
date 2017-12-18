using System;
using System.Collections.Generic;

namespace CDStore
{
   public class CD
    {
        public CD()
        {
            Songs = new List<Song>();
        }
        public virtual int CDId { get; set; }

        public virtual string Title { get; set; }

        public virtual RecordCompany RecordCompany { get; set; }

        public virtual DateTime Published { get; set; }

        public virtual List<Song> Songs { get; set; }
    }
}
