using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SurvivorLeague.Models;
using SurvivorLeague.NFL;
using SurvivorLeague.MLB;

namespace SurvivorLeague.Models
{
    public class PlayerLeagueViewModel
    {
        public int LeagueId{ get; set; }
        public string LeagueName { get; set; }
        public string LeagueType { get; set; }
        public string FavoriteTeamColors { get; set; }
    }
}