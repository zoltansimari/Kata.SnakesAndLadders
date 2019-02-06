using System;

namespace Kata.SnakesAndLadders.Domain
{
    public class Token
    {
        public string Colour { get; private set; }
        public int? Position { get; internal set; }

        public Token(string colour)
        {
            if (string.IsNullOrWhiteSpace(colour))
            {
                throw new ArgumentException("You need to specify colour.");
            }

            Colour = colour;
        }
    }
}
