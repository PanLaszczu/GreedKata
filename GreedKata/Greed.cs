using System.Collections.Generic;
using System.Linq;

namespace GreedKata
{
    public class Greed
    {
        private List<int> _diceRoll;

        public void Roll(int[] diceRoll)
        {
            _diceRoll = diceRoll.ToList();
        }

        public int Score()
        {
            Dictionary<int, int> counts = new Dictionary<int, int> {{1, 0}, {2, 0}, {3, 0}, {4, 0}, {5, 0}, {6, 0}};

            IncrementCounters(counts);

            return CalculateTotalScore(counts);
        }

        private void IncrementCounters(Dictionary<int, int> counts)
        {
            _diceRoll.ForEach(die => { counts[die] += 1; });
        }

        private int CalculateTotalScore(Dictionary<int, int> counts)
        {
            Dictionary<int, List<int>> points = new Dictionary<int, List<int>>
            {
                {1, new List<int> {100, 1000}},
                {2, new List<int> {0, 200}},
                {3, new List<int> {0, 300}},
                {4, new List<int> {0, 400}},
                {5, new List<int> {50, 500}},
                {6, new List<int> {0, 600}}
            };

            Dictionary<int, int> scores = new Dictionary<int, int>
            {
                {1, CalculateScore(counts[1], points[1][0], points[1][1])},
                {2, CalculateScore(counts[2], points[2][0], points[2][1])},
                {3, CalculateScore(counts[3], points[3][0], points[3][1])},
                {4, CalculateScore(counts[4], points[4][0], points[4][1])},
                {5, CalculateScore(counts[5], points[5][0], points[5][1])},
                {6, CalculateScore(counts[6], points[6][0], points[6][1])}
            };

            return scores.Values.Sum();
        }

        private int CalculateScore(int count, int singleScore, int tripleScore)
        {
            if (count == 1)
            {
                return singleScore;
            }

            if (count == 2)
            {
                return (2 * singleScore);
            }

            if (count == 3)
            {
                return tripleScore;
            }

            if (count > 3)
            {
                return tripleScore + (count - 3) * singleScore;
            }

            return 0;
        }
    }
}