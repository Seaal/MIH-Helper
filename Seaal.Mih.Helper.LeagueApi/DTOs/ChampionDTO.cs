﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seaal.Mih.Helper.LeagueApi
{
    public class ChampionDTO
    {
        public Dictionary<string,Champion> data { get; set; }

        public string type { get; set; }

        public string version { get; set; }
    }
}
