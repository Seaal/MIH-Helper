using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matt.Mih.Helper
{
    class LeagueInfo
    {
        public string name { get; set; }

        public string queue { get; set; }

        public string tier { get; set; }

        public List<LeagueEntry> entries { get; set; }
    }
}
