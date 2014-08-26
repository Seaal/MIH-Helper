using System;
namespace Matt.Mih.Helper
{
    public interface ILeagueDAO
    {
        ChampionDTO GetChampions();
        Runepage GetCurrentRunepage(int id);
        LeagueInfoDTO GetLeagueInfo(int id);
        SummonerDTO GetSummoner(string summonerName);
    }
}
