using FluentAssertions;
using GreedKata;
using Xunit;

namespace GreedKataTests
{
    public class GreedTests
    {
        [Theory]
        [InlineData(new[] { 1, 2, 3, 4, 6 }, 100)]
        [InlineData(new[] { 2, 2, 3, 4, 5 }, 50)]
        [InlineData(new[] { 1, 1, 1, 5, 1 }, 2050)]
        [InlineData(new[] { 3, 4, 5, 3, 3 }, 350)]
        [InlineData(new[] { 2, 3, 4, 6, 2 }, 0)]
        [InlineData(new[] { 2, 3, 4, 6, 2, 3 }, 0)]
        [InlineData(new[] { 1, 1, 2, 2, 2, 2 }, 600)]
        [InlineData(new[] { 1, 2, 2, 2, 2, 2 }, 900)]
        [InlineData(new[] { 2, 2, 2, 2, 2, 2 }, 1600)]
        [InlineData(new[] { 2, 2, 3, 3, 4, 4 }, 800)]
        [InlineData(new[] { 1, 2, 3, 4, 5, 6 }, 1200)]
        public void Score_RollingASingleOne_ShouldScore100(int[] roll, int expectedScore)
        {
            //arrange
            Greed greed = new Greed();
            int[] diceRoll = roll;
            greed.Roll(diceRoll);

            //act
            int score = greed.Score();

            //assert
            score.Should().Be(expectedScore, $"because rolling {string.Join(",", diceRoll)} should earn {expectedScore} points");
        }  
    }
}
