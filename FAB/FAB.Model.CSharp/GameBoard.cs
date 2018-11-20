using Quadrivia.FunctionalLibrary;
using System.Collections.Immutable;

namespace Quadrivia.FAB
{
    public class GameBoard
    {
        public readonly int Size;
        public readonly ImmutableHashSet<Location> Misses; //Use only immutable collections (library)
        public readonly FList<Ship> Ships;
        public readonly string Messages;

        public GameBoard(int size, FList<Ship> ships, string messages, ImmutableHashSet<Location> misses)
        {
            Size = size;
            Messages = messages;
            Ships = ships;
            Misses = misses;
        }
    }
}
