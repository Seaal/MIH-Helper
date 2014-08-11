using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matt.Mih.Helper
{
    public class LeagueInfoDTO
    {
        public string queue { get; set; }

        public string tier { get; set; }

        public List<LeagueEntryDTO> entries { get; set; }
    }
}
