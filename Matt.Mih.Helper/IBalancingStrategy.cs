using Matt.Mih.Helper.LeagueApi;
using System;

namespace Matt.Mih.Helper
{
    public interface IBalancingStrategy
    {
        BalanceResult Balance(Summoner[] players);
    }
}
