using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata.SnakesAndLadders.Domain
{
    public class Game
    {
        public Board Board { get; private set; }
        public IEnumerable<Player> Players { get; private set; } = new Player[0];
        public Player LastPlayer { get; private set; }
        public Player Winner { get; private set; }
        private readonly IDice dice = new Dice();

        public Game()
        {
            Board = new Board(1, 100);
        }

        public void AddPlayer(Player player)
        {
            if (Players.Any(p => p.Name == player.Name))
            {
                throw new ArgumentException($"This player is already in the game: { player.Name }");
            }

            player.Dice = dice;
            Players = Players.Union(new Player[] { player }); 
        }

        public void PlaceTokenOnBoard(Player player)
        {
            if (!Players.Contains(player))
            {
                throw new ArgumentException($"This player is not in the game: { player.Name }");
            }

            if (player.Token == null)
            {
                throw new ArgumentException($"This player has no token: { player.Name }");
            }

            Board.AddToken(player.Token);
        }

        public void AddPlayerAndPlaceItsTokenOnBoard(Player player)
        {
            AddPlayer(player);
            PlaceTokenOnBoard(player);
        }

        public Player NextPlayer
        {
            get
            {
                if (!Players.Any())
                {
                    return null;
                }

                if (LastPlayer == null || LastPlayer == Players.Last())
                {
                    return Players.First();
                }

                var playersArray = Players.ToArray();
                return playersArray[Array.IndexOf(playersArray, LastPlayer) + 1];
            }
        }

        public void RollAndMove(Player player)
        {
            if (!Players.Contains(player))
            {
                throw new ArgumentException($"This player is not in the game: { player.Name }");
            }

            if (player.Token == null)
            {
                throw new ArgumentException($"This player has no token: { player.Name }");
            }

            if (!Board.Tokens.Any(t => t == player.Token))
            {
                throw new ArgumentException($"This player's token is not on the board: { player.Name }");
            }

            player.Roll();
            
            if (player.Token.Position + player.Dice.LastNumber <= Board.EndPosition)
            {
                Board.MoveToken(player.Token, player.Dice.LastNumber.Value);
                
                if (Winner == null && player.Token.Position == Board.EndPosition)
                {
                    Winner = player;
                }
            }

            LastPlayer = player;
        }
    }
}
