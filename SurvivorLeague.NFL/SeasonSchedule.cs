//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SurvivorLeague.NFL
{
    using System;
    using System.Collections.Generic;
    
    public partial class SeasonSchedule
    {
        public int SeasonID { get; set; }
        public int Week { get; set; }
        public System.DateTime Date { get; set; }
        public System.TimeSpan Time { get; set; }
        public int VisitorTeamID { get; set; }
        public int HomeTeamID { get; set; }
        public string Location { get; set; }
        public string MatchupCode { get; set; }
    
        public virtual Season Season { get; set; }
        public virtual Team Team { get; set; }
        public virtual Team Team1 { get; set; }
    }
}
