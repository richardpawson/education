using System.Collections.Immutable;

namespace Boom.Model
{
    public class GameBoard
    {
        public readonly int Size;
        public readonly ImmutableList<Location> Misses;
        public readonly ImmutableArray<Ship> Ships;
        public readonly string Messages;
        /// <summary>
        /// </summary>
        /// <param name="size"></param>
        /// <param name="ships"></param>
        /// <param name="logger"></param>
        /// <param name="randomGenerator"></param>
        /// <param name="misses"></param>
        public GameBoard(int size, ImmutableArray<Ship> ships, string messages, ImmutableList<Location> misses)
        {
            Size = size;
            Messages = messages;
            Ships = ships;
            Misses = misses;
        }
    }
}