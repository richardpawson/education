using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boom.Model
{
    public struct Location
    {
        public readonly int Item1;
        public readonly int Item2;

        public Location(int col, int row)
        {
            Item1 = col;
            Item2 = row;
        }

    }
}
