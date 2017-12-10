using System.Collections.Generic;

namespace CDStore
{
    public class Artist
    {
        public virtual int ArtistId { get; set; }
        public virtual string Name { get; set; }

        public virtual List<Song> Songs { get; set; }
    }
}

