using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seaal.Mih.Helper.LeagueApi
{
    public class RuneDTO
    {
        public int id { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public Dictionary<string, double> stats { get; set; }

        public RuneMetaDTO rune { get; set; }
    }
}
