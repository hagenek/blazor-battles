﻿using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorBattles.Shared;

namespace BlazorBattles.Client.Services
{
    public interface IBattleService
    {
        IList<BattleHistoryEntry> History { get; set; }
        BattleResult LastBattle { get; set; }
        Task<BattleResult> StartBattle(int opponentId);
        Task GetHistory();
    }
}