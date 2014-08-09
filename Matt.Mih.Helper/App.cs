using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matt.Mih.Helper
{
    class App
    {
        public Summoner[] players { get; set; }

        private Dictionary<string, Champion> _champions;
        public Dictionary<string, Champion> Champions
        {
            get
            {
                if (_champions == null)
                {
                    LeagueApiDAO leagueDao = new LeagueApiDAO();
                    _champions = leagueDao.GetChampions().data;
                }

                return _champions;
            }
        }

        public App()
        {
            players = new Summoner[10];
        }

        public Summoner GetSummoner(string name, int playerNumber)
        {
            if(name == "")
            {
                throw new ArgumentException("Summoner Name Can't Be Empty");
            }

            LeagueApiDAO leagueDao = new LeagueApiDAO();

            SummonerDTO summonerDto = leagueDao.GetSummoner(name);

            LeagueInfoDTO leagueDto = leagueDao.GetLeagueInfo(summonerDto.id);

            players[playerNumber] = new Summoner(summonerDto, leagueDto);

            return players[playerNumber];
        }


    }
}
