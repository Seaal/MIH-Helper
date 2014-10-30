using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matt.Mih.Helper.LeagueApi
{
    public class Champion
    {
        public int id { get; set; }

        public string title { get; set; }

        public string name { get; set; }

        public string key { get; set; }

        public override string ToString()
        {
            return name;
        }
    }
}
