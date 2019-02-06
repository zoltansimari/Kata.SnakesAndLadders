using Kata.SnakesAndLadders.Domain;
using System;

namespace Kata.SnakesAndLadders.CommandLine
{
    public class Program
    {
        public static void Main(string[] args)
        {

            // ----- Number Of Players
            int numberOfPlayers;
            ConsoleKeyInfo pressedKey;

            do
            {
                Console.Write("Please input the number of players (or press q to exit): ");
                pressedKey = Console.ReadKey();
                if (pressedKey.Key == ConsoleKey.Q) return;
                Console.WriteLine();
            }
            while (!int.TryParse(pressedKey.KeyChar.ToString(), out numberOfPlayers));

            // ----- Player Names
            var names = new string[numberOfPlayers];
            Console.WriteLine("Please input the players' name (they all must be different)");

            for (int i = 0; i < numberOfPlayers; i++)
            {
                Console.Write($"Please input the #{i+1} player's name: ");
                names[i] = Console.ReadLine();
            }

            // ----- Token Colours
            var colours = new string[numberOfPlayers];
            Console.WriteLine("Please input the token colour for each player (they all must be different)");

            for (int i = 0; i < numberOfPlayers; i++)
            {
                Console.Write($"Please input {names[i]}'s token's colour: ");
                colours[i] = Console.ReadLine();
            }

            // ----- Game
            var game = new Game();
            Console.WriteLine("And the game begins");

            for (int i = 0; i < numberOfPlayers; i++)
            {
                game.AddPlayerAndPlaceItsTokenOnBoard(new Player(names[i]) { Token = new Token(colours[i]) });
            }

            do
            {
                var player = game.NextPlayer;
                game.RollAndMove(player);
                Console.WriteLine($"{player.Name} rolled {player.Dice.LastNumber} and now is on {player.Token.Position}");
            }
            while (game.Winner == null);

            Console.WriteLine($"The winner is: {game.Winner.Name}");
            Console.ReadKey();
        }
    }
}
