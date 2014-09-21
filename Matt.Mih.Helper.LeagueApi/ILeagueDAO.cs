using System;

namespace Matt.Mih.Helper.LeagueApi
{
    public interface ILeagueDAO
    {
        string ApiKey { get; set; }
        ChampionDTO GetChampions();
        RuneListDTO GetRunes();
        RunepageDTO GetCurrentRunepage(int id);
        LeagueInfoDTO GetLeagueInfo(int id);
        SummonerDTO GetSummoner(string summonerName);
    }
}
