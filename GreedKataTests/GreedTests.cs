using FluentAssertions;
using GreedKata;
using Xunit;

namespace GreedKataTests
{
    public class GreedTests
    {
        [Theory]
        [InlineData(new[] { 1, 2, 3, 4, 6 }, 100)]  //single 1
        [InlineData(new[] { 2, 2, 3, 4, 5 }, 50)]  //single 5
        [InlineData(new[] { 1, 1, 1, 2, 3 }, 1000)]  //triple 1's
        [InlineData(new[] { 2, 2, 2, 3, 4 }, 200)]  //triple 2's
        [InlineData(new[] { 3, 3, 3, 2, 4 }, 300)]  //triple 3's
        [InlineData(new[] { 4, 4, 4, 2, 3 }, 400)]  //triple 4's
        [InlineData(new[] { 5, 5, 5, 2, 4 }, 500)]  //triple 5's
        [InlineData(new[] { 6, 6, 6, 2, 4 }, 600)]  //triple 6's

        [InlineData(new[] { 1, 1, 1, 5, 1 }, 1150)]
        [InlineData(new[] { 2, 3, 4, 6, 2 }, 0)]
        [InlineData(new[] { 3, 4, 5, 3, 3 }, 350)]
        [InlineData(new[] { 1, 5, 1, 2, 4 }, 250)]
        [InlineData(new[] { 5, 5, 5, 5, 5 }, 600)]
        public void Score_RollingAGivenSequence_ShouldScoreAppropriately(int[] roll, int expectedScore)
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
