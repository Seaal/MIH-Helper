using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seaal.Mih.Helper.LeagueApi
{
    public class RunepageListDTO
    {
        public List<RunepageDTO> pages { get; set; }

        public int summonerId { get; set; }
    }
}
