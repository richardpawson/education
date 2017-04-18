using System.Collections.Immutable;

namespace FAB
{
    public class GameBoard
    {
        public readonly int Size;
        public readonly ImmutableList<Location> Misses;
        public readonly ImmutableArray<Ship> Ships;
        public readonly string Messages;

        public GameBoard(int size, ImmutableArray<Ship> ships, string messages, ImmutableList<Location> misses)
        {
            Size = size;
            Messages = messages;
            Ships = ships;
            Misses = misses;
        }
    }
}