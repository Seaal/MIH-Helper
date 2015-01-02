using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Seaal.Mih.Helper.LeagueApi
{
    public interface ILeagueRepository
    {
        string ApiKey { set; }
        string Region { set; }
        List<Champion> GetChampions();
        List<Rune> GetRunes();
        Runepage GetCurrentRunepage(int summonerId);
        Task<Summoner> GetSummonerAsync(string summonerName);
    }
}
