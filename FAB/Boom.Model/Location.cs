using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boom.Model
{
    public struct Location
    {
        public readonly int Col;
        public readonly int Row;

        public Location(int col, int row)
        {
            Col = col;
            Row = row;
        }

        public Location Add(int colInc, int rowInc)
        {
            return new Location(Col + colInc, Row + rowInc);
        }

    }
}
