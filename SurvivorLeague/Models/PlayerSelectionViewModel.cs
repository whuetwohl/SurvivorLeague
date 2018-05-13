using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurvivorLeague.Models
{
    public class PlayerSelectionViewModel
    {
        public int LeagueId { get; set; }
        public int SeasonId { get; set; }
        public int Week { get; set; }
        public int? SelectedTeamId { get; set; }
        public string SelectedTeamName { get; set; }
        public string TeamColors { get; set; }
        public PlayerSelectionViewModel(int leagueId, int seasonId, int week, int? selectedTeamId, string selectedTeamName, string teamColors)
        {
            LeagueId = leagueId;
            SeasonId = seasonId;
            Week = week;
            SelectedTeamId = selectedTeamId;
            SelectedTeamName = selectedTeamName;
            TeamColors = teamColors;
        }
    }
}