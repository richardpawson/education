using System;
using System.Collections.Generic;
using System.Linq;

namespace Boom.Model
{
    public class Location
    {
        //All properties are readonly ...
        public readonly int Col;
        public readonly int Row;

        //...set in the constructor and never changed
        public Location(int col, int row)
        {
            Col = col;
            Row = row;
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}", Col, Row);
        }

        public override bool Equals(object obj)
        {
            return obj is Location ?
                ((Location)obj).Col == this.Col && ((Location)obj).Row == this.Row
                : false;
        }

        public override int GetHashCode()
        {
            return Col.GetHashCode() + Row.GetHashCode();
        }
    }
}
