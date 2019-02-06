using Kata.SnakesAndLadders.Domain;
using NUnit.Framework;

namespace Kata.SnakesAndLadders.Tests
{
    [TestFixture]
    public partial class TokenTests
    {
        [Test]
        public void TokenDefaultPositionShouldBeOne()
        {
            // Given the game is started
            var player = new Player("Michael") { Token = new Token("Green") };
            var game = new Game();
            game.AddPlayer(player);
            // When the token is placed on the board
            game.PlaceTokenOnBoard(player);
            // Then the token is on square 1
            Assert.AreEqual(1, player.Token.Position);
        }

        [Test]
        public void TokenShouldMoveBySetNumber()
        {
            // Given the token is on square 1
            var player = new Player("Michael") { Token = new Token("Green") };
            var game = new Game();
            game.AddPlayer(player);
            game.PlaceTokenOnBoard(player);
            // When the token is moved 3 spaces
            game.Board.MoveToken(player.Token, 3);
            // Then the token is on square 4
            Assert.AreEqual(4, player.Token.Position);
        }

        [Test]
        public void TokenShouldMoveIncrementrally()
        {
            // Given the token is on square 1
            var player = new Player("Michael") { Token = new Token("Green") };
            var game = new Game();
            game.AddPlayer(player);
            game.PlaceTokenOnBoard(player);
            // When the token is moved 3 spaces
            game.Board.MoveToken(player.Token, 3);
            // And then it is moved 4 spaces
            game.Board.MoveToken(player.Token, 4);
            // Then the token is on square 4
            Assert.AreEqual(8, player.Token.Position);
        }

        [Test]
        public void TokenShouldMoveAccordingToRolledNumber()
        {
            // Given the player rolls a 4
            var player = new Player("Michael") { Token = new Token("Green") };
            var game = new Game();
            game.AddPlayer(player);
            game.PlaceTokenOnBoard(player);
            player.Dice = new FakeDice(4);
            var originalPosition = player.Token.Position;
            // When they move their token
            game.RollAndMove(player);
            // Then the token should move 4 spaces
            Assert.AreEqual(4, player.Token.Position - originalPosition);
        }
    }
}
