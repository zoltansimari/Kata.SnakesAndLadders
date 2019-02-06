using Kata.SnakesAndLadders.Domain;
using NUnit.Framework;

namespace Kata.SnakesAndLadders.Tests
{
    [TestFixture]
    public class DiceTests
    {
        [Test]
        [Repeat(10)]
        public void DiceRolledNumberShouldBeBetweenOneAndSix()
        {
            // Given the game is started
            var game = new Game();
            var player = new Player("Michael");
            game.AddPlayer(player);
            // When the player rolls a die
            player.Roll();
            var rolledNumber = player.Dice.LastNumber;
            // Then the result should be between 1-6 inclusive
            Assert.GreaterOrEqual(rolledNumber, 1);
            Assert.LessOrEqual(rolledNumber, 6);
        }
    }
}