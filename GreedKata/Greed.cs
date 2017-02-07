using System.Collections.Generic;
using System.Linq;

namespace GreedKata
{
    public class Greed
    {
        List<int> _diceRoll;

        public void Roll(int[] diceRoll)
        {
            _diceRoll = diceRoll.ToList();
        }

        public int Score()
        {
            Dictionary<int, int> counts = new Dictionary<int, int> { { 1, 0 }, { 2, 0 }, { 3, 0 }, { 4, 0 }, { 5, 0 }, { 6, 0 } };

            IncrementCounters(counts);

            return CalculateTotalScore(counts);
        }

        private void IncrementCounters(Dictionary<int, int> counts)
        {
            _diceRoll.ForEach(d => IncrementCounter(counts, d));
        }

        private int CalculateTotalScore(Dictionary<int, int> counts)
        {
            int straightScore = CalculateStraightScore(counts);

            if (straightScore > 0)
            {
                return straightScore;
            }

            int threePairsScore = CalculateThreePairsScore(counts);

            if (threePairsScore > 0)
            {
                return threePairsScore;
            }

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

        private int CalculateStraightScore(Dictionary<int, int> counts)
        {
            if (counts.Count(c => c.Value == 1) == 6)
            {
                return 1200;
            }

            return 0;
        }

        private static int CalculateThreePairsScore(Dictionary<int, int> counts)
        {
            if (counts.Count(c => c.Value == 2) == 3)
            {
                return 800;
            }

            return 0;
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

            if (count == 4)
            {
                return (2 * tripleScore);
            }

            if (count == 5)
            {
                return (4 * tripleScore);
            }

            if (count == 6)
            {
                return (8 * tripleScore);
            }

            return 0;
        }

        private void IncrementCounter(Dictionary<int, int> counts, int die)
        {
            counts[die] += 1;
        }
    }
}
