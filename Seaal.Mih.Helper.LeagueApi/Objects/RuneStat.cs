using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seaal.Mih.Helper.LeagueApi
{

    public enum StatType
    {
        Standard, Percent, PerLevel, PercentPerLevel
    }

    public class RuneStat
    {
        public double Value { get; set; }

        public string Description { get; set; }

        public StatType Type { get; set; }

        public RuneStat(double value, string description, string statName)
        {
            Value = value;
            Description = description;
            Type = getTypeFromStatName(statName);
        }

        private StatType getTypeFromStatName(string statName)
        {
            if(statName.StartsWith("r"))
            {
                statName = statName.Remove(0, 1);
            }

            if(statName.StartsWith("Percent"))
            {
                if(statName.EndsWith("PerLevel"))
                {
                    return StatType.PercentPerLevel;
                }
                else
                {
                    return StatType.Percent;
                }
            }
            else
            {
                if(statName.EndsWith("PerLevel"))
                {
                    return StatType.PerLevel;
                }
                else
                {
                    return StatType.Standard;
                }
            }

        }
    }
}
