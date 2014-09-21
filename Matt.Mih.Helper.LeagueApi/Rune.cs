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

        public string Description { get; set; }

        public double IncreasedStat { get; set; }

        public string Tier { get; set; }

        public RuneType Type { get; set; }

        public Rune(RuneDTO dto)
        {
            Id = dto.id;

            Name = dto.name;

            Description = dto.description;

            IncreasedStat = dto.stats.Values.FirstOrDefault();

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
    }
}
