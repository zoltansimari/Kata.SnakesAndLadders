using System;

namespace Kata.SnakesAndLadders.Domain
{
    public class Dice : IDice
    {
        public int? LastNumber { get; private set; }
        private readonly Random random = new Random();

        public int Roll()
        {
            LastNumber = random.Next(1, 7);
            return LastNumber.Value;
        }
    }
}
