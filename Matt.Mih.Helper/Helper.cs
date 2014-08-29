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

        public ILeagueDAO LeagueDao { get; private set; }

        public NameHandler Names { get; set; }

        private Dictionary<string, Champion> _champions;
        public Dictionary<string, Champion> Champions
        {
            get
            {
                if (_champions == null)
                {
                    _champions = LeagueDao.GetChampions().data;
                }

                return _champions;
            }
        }

        public Helper(ILeagueDAO leagueDao, NameHandler names)
        {
            Players = new Summoner[10];
            GameInProgress = false;
            LeagueDao = leagueDao;
            Names = names;
        }

        public Summoner GetSummoner(string name, int playerNumber)
        {
            if (name == "")
            {
                throw new ArgumentException("Player name cannot be empty.");
            }

            if (Players[playerNumber] != null && Players[playerNumber].Name.ToLower() == name.ToLower())
            {
                return Players[playerNumber];
            }

            for(int i=0;i<10;i++)
            {
                if(i != playerNumber && Players[i] != null && Players[i].Name.ToLower() == name.ToLower())
                {
                    throw new ArgumentException("Player already exists.");
                }
            }

            SummonerDTO summonerDto = LeagueDao.GetSummoner(name);

            try
            {
                LeagueInfoDTO leagueDto = LeagueDao.GetLeagueInfo(summonerDto.id);

                Players[playerNumber] = new Summoner(summonerDto, leagueDto);
            }
            catch (WebException exception)
            {
                if (exception.Status == WebExceptionStatus.ProtocolError)
                {
                    Players[playerNumber] = new Summoner(summonerDto);
                }
            }

            Names.Add(Players[playerNumber].Name);

            return Players[playerNumber];
        }

        public BalanceResult BalanceTeams()
        {
            IBalancingStrategy strat = new BruteForceBalancingStrategy();

            return strat.Balance(Players);
        }

        public List<Tuple<int, int>> PerformSwaps(BalanceResult swaps)
        {
            List<Tuple<int, int>> uiSwaps = new List<Tuple<int, int>>(2);

            foreach(Tuple<Summoner,Summoner> swap in swaps.Swaps)
            {
                int player1Index = Array.IndexOf(Players, swap.Item1);
                int player2Index = Array.IndexOf(Players, swap.Item2);

                Summoner tempPlayer = Players[player2Index];
                Players[player2Index] = Players[player1Index];
                Players[player1Index] = tempPlayer;

                uiSwaps.Add(new Tuple<int, int>(player1Index, player2Index));
            }

            return uiSwaps;
        }
    }
}
