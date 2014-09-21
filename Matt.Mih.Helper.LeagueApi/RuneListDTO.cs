using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matt.Mih.Helper.LeagueApi
{
    public class RuneListDTO
    {
        public Dictionary<string, RuneDTO> data { get; set; }

        public string type { get; set; }

        public string version { get; set; }
    }
}
