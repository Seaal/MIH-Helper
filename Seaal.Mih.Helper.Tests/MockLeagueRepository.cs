using Seaal.Mih.Helper.LeagueApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seaal.Mih.Helper.Tests
{
    class MockLeagueRepository : ILeagueRepository
    {
        public string ApiKey { get; set; }

        public string Region { get; set; }

        public List<Champion> Champions { get; set; }

        public List<Champion> GetChampions()
        {
            return Champions;
        }

        public List<Rune> Runes { get; set; }

        public List<Rune> GetRunes()
        {
            return Runes;
        }

        public Runepage GetCurrentRunepage(int summonerId)
        {
            throw new NotImplementedException();
        }

        public Task<Summoner> GetSummonerAsync(string summonerName)
        {
            throw new NotImplementedException();
        }
    }
}
