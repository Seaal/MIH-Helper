using Seaal.Mih.Helper.LeagueApi;
using System;

namespace Seaal.Mih.Helper
{
    public interface IBalancingStrategy
    {
        BalanceResult Balance(Summoner[] players);
    }
}
