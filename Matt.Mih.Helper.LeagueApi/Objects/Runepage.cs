using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matt.Mih.Helper.LeagueApi
{
    public class Runepage
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Rune> Runes { get; set; }

        public bool Current { get; set; }

        public Runepage(RunepageDTO dto, List<Rune> runes)
        {
            Id = dto.id;

            Name = dto.name;

            Runes = runes;

            Current = dto.current;
        }
    }
}
