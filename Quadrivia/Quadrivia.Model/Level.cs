using NakedObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadrivia
{
    //Represents the academic 'level' for which a Question is appropriate
    //TODO: Needs more thought e.g. Year? KS? Qualification?
    public class Level
    {

        [NakedObjectsIgnore]
        public virtual int Id { get; set; }

    }
}
