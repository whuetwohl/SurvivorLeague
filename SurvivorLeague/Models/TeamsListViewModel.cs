using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurvivorLeague.Models
{
    public class TeamsListViewModel
    {
        public int TeamId { get; set; }
        public string TeamLocation { get; set; }
        public string TeamName { get; set; }
        public string TeamLeague { get; set; }
    }
}