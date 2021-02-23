using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorBattles.Shared;

namespace BlazorBattles.Client.Services
{
    public interface ILeaderboardService
    {
        IList<UserStatistic> Leaderboard { get; set; }
        Task GetLeaderboard();  
    }
}