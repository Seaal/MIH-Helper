using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matt.Mih.Helper
{
    interface IMainFormView
    {
        List<IPlayerView> Players { get; }
        string Swap1 { set; }
        string Swap2 { set; }
        string RatingDifference { set; }
        Color RatingDifferenceTextColor { set; }
        string BalanceButtonText { set; }
        bool BalanceButtonEnabled { set; }
        string GameToggleButtonText { set; }
        bool ClearAllButtonEnabled { set; }

        event EventHandler BalanceTeamsClick;
        event EventHandler GameToggleClick;
        event EventHandler ClearAllClick;
    }
}
