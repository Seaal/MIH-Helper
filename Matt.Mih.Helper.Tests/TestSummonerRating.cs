using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Matt.Mih.Helper.LeagueApi;

namespace Matt.Mih.Helper.Tests
{
    [TestClass]
    public class TestSummonerRating
    {
        [TestMethod]
        public void TestUnrankedRating()
        {
            Summoner summ = summonerHelper("UNRANKED", "", 0);

            Assert.IsTrue(summ.GetRating() == 500);
        }

        [TestMethod]
        public void TestBronzeVRating()
        {
            Summoner summ = summonerHelper("BRONZE", "V", 0);

            Assert.IsTrue(summ.GetRating() == 0);
        }

        [TestMethod]
        public void TestSilverVRating()
        {
            Summoner summ = summonerHelper("SILVER", "V", 0);

            Assert.IsTrue(summ.GetRating() == 500);
        }

        [TestMethod]
        public void TestGoldVRating()
        {
            Summoner summ = summonerHelper("GOLD", "V", 0);

            Assert.IsTrue(summ.GetRating() == 1000);
        }

        [TestMethod]
        public void TestPlatinumVRating()
        {
            Summoner summ = summonerHelper("PLATINUM", "V", 0);

            Assert.IsTrue(summ.GetRating() == 1500);
        }

        [TestMethod]
        public void TestDiamondVRating()
        {
            Summoner summ = summonerHelper("DIAMOND", "V", 0);

            Assert.IsTrue(summ.GetRating() == 2000);
        }

        [TestMethod]
        public void TestChallengerIRating()
        {
            Summoner summ = summonerHelper("CHALLENGER", "I", 0);

            Assert.IsTrue(summ.GetRating() == 2500);
        }

        [TestMethod]
        public void TestLPRating()
        {
            Summoner summ = summonerHelper("CHALLENGER", "I", 527);

            Assert.IsTrue(summ.GetRating() == 3027);
        }

        [TestMethod]
        public void TestBronzeIVRating()
        {
            Summoner summ = summonerHelper("BRONZE", "IV", 0);

            Assert.IsTrue(summ.GetRating() == 100);
        }

        [TestMethod]
        public void TestBronzeIIIRating()
        {
            Summoner summ = summonerHelper("BRONZE", "III", 0);

            Assert.IsTrue(summ.GetRating() == 200);
        }

        [TestMethod]
        public void TestBronzeIIRating()
        {
            Summoner summ = summonerHelper("BRONZE", "II", 0);

            Assert.IsTrue(summ.GetRating() == 300);
        }

        [TestMethod]
        public void TestBronzeIRating()
        {
            Summoner summ = summonerHelper("BRONZE", "I", 0);

            Assert.IsTrue(summ.GetRating() == 400);
        }

        private Summoner summonerHelper(string tier, string division, int lp)
        {
            Summoner sum = new Summoner();
            sum.Tier = tier;
            sum.Division = division;
            sum.LeaguePoints = lp;

            return sum;
        }
    }
}
