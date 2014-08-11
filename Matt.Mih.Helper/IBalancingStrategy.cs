using System;
namespace Matt.Mih.Helper
{
    interface IBalancingStrategy
    {
        BalanceResult balance(Summoner[] players);
    }
}
