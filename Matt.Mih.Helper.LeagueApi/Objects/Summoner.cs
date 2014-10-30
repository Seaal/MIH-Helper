using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matt.Mih.Helper.LeagueApi
{
    public class Summoner
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Level { get; set; }

        public string Tier { get; set; }

        public string Division { get; set; }

        public int LeaguePoints { get; set; }

        public Summoner(SummonerDTO summonerDto, LeagueInfoDTO leagueDto)
        {
            Id = summonerDto.id;
            Name = summonerDto.name;
            Level = summonerDto.summonerLevel;
            Tier = leagueDto.tier;
            Division = leagueDto.entries[0].division;
            LeaguePoints = leagueDto.entries[0].leaguePoints;
        }

        public Summoner(SummonerDTO summonerDto)
        {
            Id = summonerDto.id;
            Name = summonerDto.name;
            Level = summonerDto.summonerLevel;
            Tier = "UNRANKED";
            Division = "";
            LeaguePoints = 0;
        }

        public Summoner(string name, int rating)
        {
            Id = 0;
            Name = name;
            Level = 30;
            LeaguePoints = rating;
            Tier = "BRONZE";
            Division = "V";
        }

        public Summoner()
        {
        }

        public int GetRating()
        {
            int rating;

            switch(Tier)
            {
                case "BRONZE":
                    rating = 0;
                    break;
                case "SILVER":
                    rating = 500;
                    break;
                case "GOLD":
                    rating = 1000;
                    break;
                case "PLATINUM":
                    rating = 1500;
                    break;
                case "DIAMOND":
                    rating = 2000;
                    break;
                case "MASTER":
                case "CHALLENGER":
                    rating = 2100;
                    break;
                case "UNRANKED":
                    rating = 500;
                    break;
                default:
                    rating = 0;
                    break;
            }

            switch(Division)
            {
                case "V":
                    rating += 0;
                    break;
                case "IV":
                    rating += 100;
                    break;
                case "III":
                    rating += 200;
                    break;
                case "II":
                    rating += 300;
                    break;
                case "I":
                    rating += 400;
                    break;
                default:
                    rating += 0;
                    break;
            }

            rating += LeaguePoints;

            return rating;
        }
    }
}
