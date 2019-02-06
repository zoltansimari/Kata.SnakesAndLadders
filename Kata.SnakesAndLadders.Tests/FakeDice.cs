using Kata.SnakesAndLadders.Domain;

namespace Kata.SnakesAndLadders.Tests
{
    public class FakeDice : IDice
    {
        private readonly int fixNumber;
        public int? LastNumber => fixNumber;
        public int Roll() => fixNumber;

        public FakeDice(int fixNumber)
        {
            this.fixNumber = fixNumber;
        }
    }
}
