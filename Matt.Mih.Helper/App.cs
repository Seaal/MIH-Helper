using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
                throw new ArgumentException("Player Name Cannot Be Empty");
            }

            if (players[playerNumber] != null && players[playerNumber].Name.ToLower() == name.ToLower())
            {
                return players[playerNumber];
            }

            LeagueApiDAO leagueDao = new LeagueApiDAO();

            SummonerDTO summonerDto = leagueDao.GetSummoner(name);

            try
            {
                LeagueInfoDTO leagueDto = leagueDao.GetLeagueInfo(summonerDto.id);

                players[playerNumber] = new Summoner(summonerDto, leagueDto);
            }
            catch(WebException exception)
            {
                if(exception.Status == WebExceptionStatus.ProtocolError)
                {
                    players[playerNumber] = new Summoner(summonerDto);
                }
            }
            

            return players[playerNumber];
        }


    }
}
