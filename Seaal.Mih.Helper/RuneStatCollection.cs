using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seaal.Mih.Helper.LeagueApi;

namespace Seaal.Mih.Helper
{
    public class RuneStatCollection
    {
        public RuneStat Stat { get; set; }

        public int StatCount { get; set; }

        public RuneStatCollection(RuneStat stat)
        {
            Stat = stat;
            StatCount = 1;
        }

        public override string ToString()
        {
            return getStat();
        }

        private string getStat()
        {
            switch(Stat.Type)
            {
                case StatType.Standard:
                    return (Stat.Value > 0 ? "+" : "") + Stat.Value * StatCount + " " + Stat.Description;
                case StatType.Percent:
                    return (Stat.Value > 0 ? "+" : "") + Stat.Value * StatCount * 100 + "% " + Stat.Description;
                case StatType.PerLevel:
                    return (Stat.Value > 0 ? "+" : "") + Stat.Value * StatCount + " " + Stat.Description + " (" + (Stat.Value > 0 ? "+" : "") + Stat.Value * StatCount * 18 + " at level 18)";
                case StatType.PercentPerLevel:
                    return (Stat.Value > 0 ? "+" : "") + Stat.Value * StatCount * 100 + "% " + Stat.Description + " (" + (Stat.Value > 0 ? "+" : "") + Stat.Value * StatCount * 18 * 100 + "% at level 18)";
                default:
                    throw new ArgumentException("Stat Type is Unknown.");
            }
        }
    }
}
