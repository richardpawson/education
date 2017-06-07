using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolymorphicSorting
{
    public class SportsTeam
    {
        public SportsTeam(string name, int netWins)
        {
            Name = name;
            NetWinsThisSeason = netWins;
        }
        public string Name { get; set; }

        public int NetWinsThisSeason { get; set; }

        public bool IsBefore(SportsTeam other)
        {
            return this.NetWinsThisSeason > other.NetWinsThisSeason;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
