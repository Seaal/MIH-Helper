using System;
using System.Collections.Generic;

namespace Matt.Mih.Helper.LeagueApi
{
    public interface ILeagueRepository
    {
        string ApiKey { set; }
        string Region { set; }
        List<Champion> GetChampions();
        List<Rune> GetRunes();
        Runepage GetCurrentRunepage(int id);
        Summoner GetSummoner(string summonerName);
    }
}
