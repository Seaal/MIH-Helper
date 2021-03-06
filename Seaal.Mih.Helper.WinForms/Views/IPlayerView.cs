﻿using Seaal.Mih.Helper.LeagueApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seaal.Mih.Helper.WinForms
{
    public interface IPlayerView
    {
        string PlayerName { get; set; }
        AutoCompleteStringCollection ExistingNames { set; }
        string Elo { get; set; }
        List<Champion> Champions { get; set; }
        string ChampionIconPath { set; }
        int SelectedChampionIndex { get; set; }
        Champion SelectedChampion { get; }
        string Error { get; set; }
        bool Enabled { get; set; }

        event EventHandler PlayerNameTextboxLeave;
        event EventHandler ChampionSelectedChanged;
    }
}
