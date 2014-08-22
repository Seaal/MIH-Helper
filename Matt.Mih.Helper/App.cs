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
    public class App
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


                XDocument namesList;

                try
                {
                    namesList = XDocument.Load("names.xml");
                }
                catch(FileNotFoundException)
                {
                    namesList = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XElement("SummonerNames"));
                }

                if(!namesList.Descendants("Name").Where(x => x.Value == players[playerNumber].Name).Any())
                {
                    XElement newName = new XElement("Name");

                    newName.Add(players[playerNumber].Name);

                    namesList.Element("SummonerNames").Add(newName);

                    namesList.Save("names.xml");
                }
            }
            catch (WebException exception)
            {
                if (exception.Status == WebExceptionStatus.ProtocolError)
                {
                    players[playerNumber] = new Summoner(summonerDto);
                }
            }


            return players[playerNumber];
        }

        public BalanceResult BalanceTeams()
        {
            Summoner[] test = summonerHelper(100, 200, 300, 400, 500, 600, 700, 800, 900, 1000);

            IBalancingStrategy strat = new BruteForceBalancingStrategy();

            return strat.Balance(test);
        }

        private Summoner[] summonerHelper(int rating0, int rating1, int rating2, int rating3, int rating4, int rating5, int rating6, int rating7, int rating8, int rating9)
        {
            Summoner[] summoners = new Summoner[10];

            summoners[0] = new Summoner("Sum0", rating0);
            summoners[1] = new Summoner("Sum1", rating1);
            summoners[2] = new Summoner("Sum2", rating2);
            summoners[3] = new Summoner("Sum3", rating3);
            summoners[4] = new Summoner("Sum4", rating4);
            summoners[5] = new Summoner("Sum5", rating5);
            summoners[6] = new Summoner("Sum6", rating6);
            summoners[7] = new Summoner("Sum7", rating7);
            summoners[8] = new Summoner("Sum8", rating8);
            summoners[9] = new Summoner("Sum9", rating9);

            return summoners;
        }
    }
}
