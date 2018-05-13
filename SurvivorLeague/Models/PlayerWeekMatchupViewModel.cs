using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SurvivorLeague.NFL;

namespace SurvivorLeague.Models
{
    public class WeeklyMatchupsViewModel
    {
        public string LeagueName { get; set; }
        public int LeagueId { get; set; }
        public int SeasonId { get; set; }
        public int Week { get; set; }
        public List<PlayerWeekMatchupViewModel> Matchups { get; set; }
        public List<SelectedTeam> SelectedTeams { get; set; }
    }

    public class PlayerWeekMatchupViewModel
    {
        public DateTime DateAndTime { get; set; }
        public Team VisitorTeam { get; set; }
        public Team HomeTeam { get; set; }
       // public int? SelectedTeamId { get; set; }
        
        public PlayerWeekMatchupViewModel(NFLLeagueEntities nfl, DateTime dateAndTime, int visitorTeamId, int homeTeamId)
        {
            DateAndTime = dateAndTime;
            VisitorTeam = (from team in nfl.Teams
                           where team.ID == visitorTeamId
                           select new Team { Id = team.ID, Location = team.Location, Name = team.Name, Colors = team.Colors }).FirstOrDefault();
            HomeTeam = (from team in nfl.Teams
                           where team.ID == homeTeamId
                           select new Team { Id = team.ID, Location = team.Location, Name = team.Name, Colors = team.Colors }).FirstOrDefault();
        }
    }

    public class Team
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public string Name { get; set; }
        public string Colors { get; set; }
    }

    public class SelectedTeam
    {
        public int Week { get; set; }
        public int TeamId { get; set; }
    }

}