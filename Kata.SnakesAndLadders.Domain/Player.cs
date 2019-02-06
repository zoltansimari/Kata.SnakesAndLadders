using System;

namespace Kata.SnakesAndLadders.Domain
{
    public class Player
    {
        public string Name { get; private set; }
        public IDice Dice { get; set; }
        public Token Token { get; set; }

        public Player(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("You need to specify name.");
            }

            Name = name;
        }

        public void Roll()
        {
            if (Dice == null)
            {
                throw new ArgumentException($"This player has no dice: { Name }");
            }

            Dice.Roll();
        }
    }
}
