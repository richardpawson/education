using System;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using TechnicalServices;

namespace Boom.Model
{
    public class GameBoard
    {
        public readonly int Size;
        public readonly ImmutableList<Tuple<int, int>> Misses;
        public readonly ImmutableArray<Ship> Ships;
        public readonly Random RandomGenerator;
        public readonly string Messages;
        /// <summary>
        /// </summary>
        /// <param name="size"></param>
        /// <param name="ships"></param>
        /// <param name="logger"></param>
        /// <param name="randomGenerator"></param>
        /// <param name="misses"></param>
        public GameBoard(int size, ImmutableArray<Ship> ships, string messages,Random randomGenerator, ImmutableList<Tuple<int, int>> misses)
        {
            Size = size;
            Messages = messages;
            RandomGenerator = randomGenerator;
            Ships = ships;
            Misses = misses;
        }
    }
}