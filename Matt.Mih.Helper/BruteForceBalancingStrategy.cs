using Combinatorics.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matt.Mih.Helper
{
    public class BruteForceBalancingStrategy : IBalancingStrategy
    {
        public BalanceResult Balance(Summoner[] players)
        {
            if(players.Length != 10)
            {
                throw new ArgumentException("10 players required to balance the teams.");
            }
            else
            {
                for(int i=0;i<10;i++)
                {
                    if(players[i] == null)
                    {
                        throw new ArgumentException("10 players required to balance the teams.");
                    }
                }
            }

            int lowestRatingDiff = Int32.MaxValue;
            IList<Summoner> finalTeam1 = null;
            IList<Summoner> finalTeam2 = null;
            
            Combinations<Summoner> combinations = new Combinations<Summoner>(players,5);

            foreach(IList<Summoner> team1 in combinations)
            {
                IList<Summoner> team2 = getTeam2(players, team1);

                int team1Rating = getTotalRating(team1);
                int team2Rating = getTotalRating(team2);

                if(Math.Abs(team1Rating - team2Rating) < lowestRatingDiff)
                {
                    lowestRatingDiff = Math.Abs(team1Rating - team2Rating);
                    finalTeam1 = team1;
                    finalTeam2 = team2;
                }
            }

            return getBalanceResult(players, finalTeam1, finalTeam2, lowestRatingDiff);
        }

        private int getTotalRating(IList<Summoner> team)
        {
            int rating = 0;

            foreach(Summoner summ in team)
            {
                rating += summ.GetRating();
            }
             
            return rating;
        }

        private IList<Summoner> getTeam2(Summoner[] players, IList<Summoner> team1)
        {
            return players.Except(team1).ToList();
        }

        private BalanceResult getBalanceResult(Summoner[] players, IList<Summoner> team1, IList<Summoner> team2, int ratingDifference)
        {
            if(team1 == null)
            {
                throw new ArgumentNullException("Team 1 is null");
            }

            if (team2 == null)
            {
                throw new ArgumentNullException("Team 2 is null");
            }

            IList<Summoner> originalTeam1 = new ArraySegment<Summoner>(players, 0, 5);
            IList<Summoner> originalTeam2 = new ArraySegment<Summoner>(players, 5, 5);

            IList<Summoner> team1SwappedPlayers = team2.Except(originalTeam2).ToList();
            IList<Summoner> team2SwappedPlayers = team1.Except(originalTeam1).ToList();

            if(team1SwappedPlayers.Count > 2)
            {
                team1SwappedPlayers = team1.Except(originalTeam2).ToList();
                team2SwappedPlayers = team2.Except(originalTeam1).ToList();
            }

            BalanceResult result = new BalanceResult(ratingDifference);

            for(int i=0;i<team1SwappedPlayers.Count;i++)
            {
                result.Swaps.Add(new Tuple<Summoner, Summoner>(team1SwappedPlayers[i],team2SwappedPlayers[i]));
            }

            return result;
        }
    }  
}
