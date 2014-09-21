using Matt.Mih.Helper.LeagueApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matt.Mih.Helper
{
    public class BalanceResult
    {
        public List<Tuple<Summoner, Summoner>> Swaps { get; set; }

        public int RatingDifference { get; set; }

        public BalanceResult(int ratingDifference)
        {
            Swaps = new List<Tuple<Summoner, Summoner>>(5);
            RatingDifference = ratingDifference;
        }
    }
}
