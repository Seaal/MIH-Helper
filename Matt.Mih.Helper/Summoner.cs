using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matt.Mih.Helper
{
    class Summoner
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int SummonerLevel { get; set; }

        public string Tier { get; set; }

        public string Division { get; set; }

        public int LeaguePoints { get; set; }

        public Summoner(SummonerDTO summonerDto, LeagueInfoDTO leagueDto)
        {
            Id = summonerDto.id;
            Name = summonerDto.name;
            SummonerLevel = summonerDto.summonerLevel;
            Tier = leagueDto.tier;
            Division = leagueDto.entries[0].division;
            LeaguePoints = leagueDto.entries[0].leaguePoints;
        }
    }
}
