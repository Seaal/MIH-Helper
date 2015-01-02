using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seaal.Mih.Helper.LeagueApi
{
    public class RunepageDTO
    {
        public int id { get; set; }

        public List<RuneSlotDTO> slots { get; set; }

        public string name { get; set; }

        public bool current { get; set; }
    }
}
