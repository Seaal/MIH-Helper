using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matt.Mih.Helper
{
    public class Runepage
    {
        public int id { get; set; }

        public List<Rune> slots { get; set; }

        public string name { get; set; }

        public bool current { get; set; }
    }
}
