using System.Collections.Generic;

namespace CDStore
{
    public class Song
    {
        public virtual int SongId { get; set; }

        public virtual string Title { get; set; }

        public virtual Artist Artist { get; set; }

        public virtual string MusicType { get; set; }

        public virtual List<CD> CDs { get; set; }
    }
}

