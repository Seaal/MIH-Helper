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

        public INameService NameService { get; set; }

        public ISettingsService SettingsService { get; set; }

        public List<Champion> Champions
        {
            get
            {
                return LeagueRepository.GetChampions();
            }
        }

        public List<Rune> Runes
        {
            get
            {
                return LeagueRepository.GetRunes();
            }
        }

        public Helper(ILeagueRepository leagueRepository, INameService names, ISettingsService settings)
        {
            Players = new Summoner[10];
            GameInProgress = false;
            LeagueRepository = leagueRepository;
            NameService = names;
            SettingsService = settings;
        }

        public async Task<Summoner> GetSummonerAsync(string name, int playerNumber)
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

            for (int i = 0; i < 10; i++)
            {
                if (i != playerNumber && Players[i] != null && Players[i].Name.ToLower() == name.ToLower())
                {
                    throw new ArgumentException("Player already exists.");
                }
            }

            Players[playerNumber] = await LeagueRepository.GetSummonerAsync(name);

            NameService.Add(Players[playerNumber].Name);

            return Players[playerNumber];
        }

        public RunepageStats GetRunepageStats(int playerNumber)
        {
            Summoner player = Players[playerNumber];

            Runepage runepage = LeagueRepository.GetCurrentRunepage(player.Id);

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
