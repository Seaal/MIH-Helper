using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matt.Mih.Helper.LeagueApi
{
    public enum RuneType
    {
        Mark, Seal, Glyph, Quintessence, Unknown
    }

    public class Rune
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<RuneStat> Stats { get; set; }

        public string Tier { get; set; }

        public RuneType Type { get; set; }

        public Rune(RuneDTO dto)
        {
            Id = dto.id;

            Name = dto.name;

            Stats = new List<RuneStat>(2);

            char positivity = dto.description[0];

            string[] descriptions = dto.description.Split(positivity);

            List<double> statValues = dto.stats.Values.ToList();

            List<string> statNames = dto.stats.Keys.ToList();

            for (int i = 0; i < dto.stats.Count; i++)
            {
                Stats.Add(new RuneStat(statValues[i], getDescriptionText(descriptions[i+1]), statNames[i]));
            }

            string description = getDescriptionText(dto.description);

            Tier = dto.rune.tier;

            switch(dto.rune.type)
            {
                case "red":
                    Type = RuneType.Mark;
                    break;
                case "yellow":
                    Type = RuneType.Seal;
                    break;
                case "blue":
                    Type = RuneType.Glyph;
                    break;
                case "black":
                    Type = RuneType.Quintessence;
                    break;
                default:
                    Type = RuneType.Unknown;
                    break;
            }
        }

        private string getDescriptionText(string description)
        {
            string[] parts = description.Split(null);

            int partsToCombine = 1;

            bool reachedBracketOrSlash = false;

            while(!reachedBracketOrSlash && partsToCombine < parts.Length)
            {
                if (parts[partsToCombine].StartsWith("(") || parts[partsToCombine].StartsWith("/"))
                {
                    reachedBracketOrSlash = true;
                }
                else
                {
                    partsToCombine++;
                }
            }

            return string.Join(" ", parts, 1, partsToCombine - 1);
        }
    }
}
