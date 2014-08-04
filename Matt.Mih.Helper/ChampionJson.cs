using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matt.Mih.Helper
{
    public class ChampionJson
    {
        public Dictionary<string,Champion> data { get; set; }

        public string type { get; set; }

        public string version { get; set; }
    }
}
