using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Seaal.Mih.Helper.LeagueApi;

namespace Seaal.Mih.Helper
{
    public class RunepageStats
    {
        public List<RuneStatCollection> MarkStats { get; set; }

        public List<RuneStatCollection> SealStats { get; set; }

        public List<RuneStatCollection> GlpyhStats { get; set; }

        public List<RuneStatCollection> QuintessenceStats { get; set; }

        public RunepageStats()
        {
            MarkStats = new List<RuneStatCollection>(9);
            SealStats = new List<RuneStatCollection>(9);
            GlpyhStats = new List<RuneStatCollection>(9);
            QuintessenceStats = new List<RuneStatCollection>(3);
        }

        public void AddStat(RuneType type, RuneStat stat)
        {
            List<RuneStatCollection> stats = getListFromType(type);

            RuneStatCollection statCollection = stats.Where(o => o.Stat.Equals(stat)).FirstOrDefault();

            if(statCollection == null)
            {
                stats.Add(new RuneStatCollection(stat));
            }
            else
            {
                statCollection.StatCount++;
            }
        }

        private List<RuneStatCollection> getListFromType(RuneType type)
        {
            switch(type)
            {
                case RuneType.Mark:
                    return MarkStats;
                case RuneType.Seal:
                    return SealStats;
                case RuneType.Glyph:
                    return GlpyhStats;
                case RuneType.Quintessence:
                    return QuintessenceStats;
                default:
                    throw new ArgumentException("Rune Type is Unkown.");
            }
        }
    }
}
