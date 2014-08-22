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

        public Helper()
        {
            players = new Summoner[10];
        }

        public Summoner GetSummoner(string name, int playerNumber)
        {
            if (name == "")
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
            catch (WebException exception)
            {
                if (exception.Status == WebExceptionStatus.ProtocolError)
                {
                    players[playerNumber] = new Summoner(summonerDto);
                }
            }

            XDocument namesList;

            try
            {
                namesList = XDocument.Load("names.xml");
            }
            catch (FileNotFoundException)
            {
                namesList = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XElement("SummonerNames"));
            }

            if (!namesList.Descendants("Name").Where(x => x.Value == players[playerNumber].Name).Any())
            {
                XElement newName = new XElement("Name");

                newName.Add(players[playerNumber].Name);

                namesList.Element("SummonerNames").Add(newName);

                namesList.Save("names.xml");
            }

            return players[playerNumber];
        }

        public BalanceResult BalanceTeams()
        {
            IBalancingStrategy strat = new BruteForceBalancingStrategy();

            return strat.Balance(players);
        }
    }
}
