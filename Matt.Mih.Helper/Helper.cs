using Matt.Mih.Helper.LeagueApi;
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

        public ILeagueRepository LeagueRepository { get; private set; }

        public NameManager Names { get; set; }

        public SettingsManager Settings { get; set; }

        public Dictionary<string, Champion> Champions
        {
            get
            {
                return LeagueRepository.GetChampions().ToDictionary(o => o.name);
            }
        }

        public List<Rune> Runes
        {
            get
            {
                return LeagueRepository.GetRunes();
            }
        }

        public Helper(ILeagueRepository leagueRepository, NameManager names, SettingsManager settings)
        {
            Players = new Summoner[10];
            GameInProgress = false;
            LeagueRepository = leagueRepository;
            Names = names;
            Settings = settings;
        }

        public Summoner GetSummoner(string name, int playerNumber)
        {
            if (name == "")
            {
                Players[playerNumber] = null;

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

            Players[playerNumber] = LeagueRepository.GetSummoner(name);

            Names.Add(Players[playerNumber].Name);

            return Players[playerNumber];
        }

        public Runepage GetRunepage(int playerNumber)
        {
            Summoner seaal = GetSummoner("Seaal", 0);

            return LeagueRepository.GetCurrentRunepage(seaal.Id);
        }

        public RunepageStats GetRunepageStats(Runepage runepage)
        {
            RunepageStats stats = new RunepageStats();

            foreach (RuneType type in Enum.GetValues(typeof(RuneType)))
            {
                foreach(Rune rune in runepage.Runes.Where(o => o.Type == type))
                {
                    foreach(RuneStat stat in rune.Stats)
                    {
                        stats.AddStat(type, stat);
                    }
                    
                }
            }

            return stats;
        }

        public BalanceResult BalanceTeams()
        {
            IBalancingStrategy strat = new BruteForceBalancingStrategy();

            return strat.Balance(Players);
        }

        public List<Tuple<int, int>> PerformSwaps(BalanceResult balanceResult)
        {
            List<Tuple<int, int>> uiSwaps = new List<Tuple<int, int>>(2);

            foreach(Tuple<Summoner,Summoner> swap in balanceResult.Swaps)
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

        public void ClearPlayers()
        {
            for(int i=0;i<10;i++)
            {
                Players[i] = null;
            }
        }
    }
}
