using System;
namespace Matt.Mih.Helper
{
    public interface IBalancingStrategy
    {
        BalanceResult balance(Summoner[] players);
    }
}
