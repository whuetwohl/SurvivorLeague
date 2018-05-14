using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurvivorLeague.Models
{
    public class UpdatePick
    {
        public int LeagueId { get; set; }
        public int SeasonId { get; set; }
        public int Week { get; set; }
        public int TeamId { get; set; }
    }
}