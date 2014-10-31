using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matt.Mih.Helper
{
    public interface IIconPathService
    {
        string GetIconPath(string champion, string leagueFolder);
        bool IsValidIconPath(string leagueFolder);
    }
}
