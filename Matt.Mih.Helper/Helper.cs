using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Matt.Mih.Helper
{
    public class Helper
    {
        public Summoner[] Players { get; set; }

        public bool GameInProgress { get; set; }

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

        public Helper()
        {
            Players = new Summoner[10];
            GameInProgress = false;
        }

        public Summoner GetSummoner(string name, int playerNumber)
        {
            if (name == "")
            {
                throw new ArgumentException("Player name cannot be empty");
            }

            if (Players[playerNumber] != null && Players[playerNumber].Name.ToLower() == name.ToLower())
            {
                return Players[playerNumber];
            }

            for(int i=0;i<10;i++)
            {
                if(i != playerNumber && Players[i] != null && Players[i].Name.ToLower() == name.ToLower())
                {
                    throw new ArgumentException("Player already exists");
                }
            }

            LeagueApiDAO leagueDao = new LeagueApiDAO();

            SummonerDTO summonerDto = leagueDao.GetSummoner(name);

            try
            {
                LeagueInfoDTO leagueDto = leagueDao.GetLeagueInfo(summonerDto.id);

                Players[playerNumber] = new Summoner(summonerDto, leagueDto);
            }
            catch (WebException exception)
            {
                if (exception.Status == WebExceptionStatus.ProtocolError)
                {
                    Players[playerNumber] = new Summoner(summonerDto);
                }
            }

            NameHandler.GetInstance().Add(Players[playerNumber].Name);

            return Players[playerNumber];
        }

        public BalanceResult BalanceTeams()
        {
            IBalancingStrategy strat = new BruteForceBalancingStrategy();

            return strat.Balance(Players);
        }
    }
}
