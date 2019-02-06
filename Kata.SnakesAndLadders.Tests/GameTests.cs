using Kata.SnakesAndLadders.Domain;
using NUnit.Framework;

namespace Kata.SnakesAndLadders.Tests
{
    [TestFixture]
    public class GameTests
    {
        [Test]
        public void PlayerLandingOnOneHundredShouldWin()
        {
            // Given the token is on square 97
            var player = new Player("Michael") { Token = new Token("Green") };
            var game = new Game();
            game.AddPlayerAndPlaceItsTokenOnBoard(player);
            game.Board.MoveToken(player.Token, 96);
            // When the token is moved 3 spaces
            player.Dice = new FakeDice(3);
            game.RollAndMove(player);
            // Then the token is on square 100
            Assert.AreEqual(100, player.Token.Position);
            // And the player has won the game
            Assert.AreEqual(game.Winner, player);
        }

        [Test]
        public void PlayerHasToFinishWithExactRemainingDistanceRolled()
        {
            // Given the token is on square 97
            var player = new Player("Michael") { Token = new Token("Green") };
            var game = new Game();
            game.AddPlayerAndPlaceItsTokenOnBoard(player);
            game.Board.MoveToken(player.Token, 96);
            // When the token is moved 4 spaces
            player.Dice = new FakeDice(4);
            game.RollAndMove(player);
            // Then the token is on square 97
            Assert.AreEqual(97, player.Token.Position);
            // And the player has not won the game
            Assert.AreNotEqual(game.Winner, player);
        }
    }
}