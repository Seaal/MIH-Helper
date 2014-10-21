using Matt.Mih.Helper.LeagueApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matt.Mih.Helper.Tests
{
    class MockLeagueRepository : ILeagueRepository
    {
        public string ApiKey { set; }

        public string Region { set; }

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

        public Summoner GetSummoner(string summonerName)
        {
            throw new NotImplementedException();
        }
    }
}
