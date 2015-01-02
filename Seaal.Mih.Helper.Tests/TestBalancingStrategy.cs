using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Seaal.Mih.Helper.LeagueApi;

namespace Seaal.Mih.Helper.Tests
{
    [TestClass]
    public class TestBalancingStrategy
    {
        [TestMethod]
        public void TestBruteForceLessThan10Players()
        {
            ArgumentException ex = null;

            Summoner[] summoners = new Summoner[10];

            summoners[0] = new Summoner("Sum0", 0);

            try
            {
                IBalancingStrategy strategy = new BruteForceBalancingStrategy();

                BalanceResult result = strategy.Balance(summoners);
            }
            catch(ArgumentException e)
            {
                ex = e;
            }
            
            Assert.IsNotNull(ex);
        }

        [TestMethod]
        public void TestBruteForceAllSameRating()
        {
            Summoner[] summoners = summonerHelper(100, 100, 100, 100, 100, 100, 100, 100, 100, 100);

            IBalancingStrategy strategy = new BruteForceBalancingStrategy();

            BalanceResult result = strategy.Balance(summoners);

            Assert.IsTrue(result.Swaps.Count == 0);
            Assert.IsTrue(result.RatingDifference == 0);
        }

        [TestMethod]
        public void TestBruteForceTwoDifferentRating()
        {
            Summoner[] summoners = summonerHelper(200, 200, 100, 100, 100, 100, 100, 100, 100, 100);

            IBalancingStrategy strategy = new BruteForceBalancingStrategy();

            BalanceResult result = strategy.Balance(summoners);

            Assert.IsTrue(result.Swaps.Count == 1);
            Assert.IsTrue(result.RatingDifference == 0);
        }

        [TestMethod]
        public void TestBruteForceAllDifferentRatingBalanced()
        {
            Summoner[] summoners = summonerHelper(100, 300, 500, 700, 900, 150, 250, 600, 750, 750);

            IBalancingStrategy strategy = new BruteForceBalancingStrategy();

            BalanceResult result = strategy.Balance(summoners);

            Assert.IsTrue(result.Swaps.Count == 0);
            Assert.IsTrue(result.RatingDifference == 0);
        }

        [TestMethod]
        public void TestBruteForceAllDifferentRatingUnbalanced()
        {
            Summoner[] summoners = summonerHelper(100, 200, 300, 400, 500, 600, 700, 800, 900, 1000);

            IBalancingStrategy strategy = new BruteForceBalancingStrategy();

            BalanceResult result = strategy.Balance(summoners);

            Assert.IsTrue(result.Swaps.Count == 2);
            Assert.IsTrue(result.RatingDifference == 100);
        }

        [TestMethod]
        public void TestBruteForce1DifferentRatingNoSwaps()
        {
            Summoner[] summoners = summonerHelper(100, 100, 100, 100, 100, 100, 100, 100, 100, 105);

            IBalancingStrategy strategy = new BruteForceBalancingStrategy();

            BalanceResult result = strategy.Balance(summoners);

            Assert.IsTrue(result.Swaps.Count == 0);
            Assert.IsTrue(result.RatingDifference == 5);
        }

        private Summoner[] summonerHelper(int rating0, int rating1, int rating2, int rating3, int rating4, int rating5, int rating6, int rating7, int rating8, int rating9)
        {
            Summoner[] summoners = new Summoner[10];

            summoners[0] = new Summoner("Sum0", rating0);
            summoners[1] = new Summoner("Sum1", rating1);
            summoners[2] = new Summoner("Sum2", rating2);
            summoners[3] = new Summoner("Sum3", rating3);
            summoners[4] = new Summoner("Sum4", rating4);
            summoners[5] = new Summoner("Sum5", rating5);
            summoners[6] = new Summoner("Sum6", rating6);
            summoners[7] = new Summoner("Sum7", rating7);
            summoners[8] = new Summoner("Sum8", rating8);
            summoners[9] = new Summoner("Sum9", rating9);

            return summoners;
        }
    }
}
