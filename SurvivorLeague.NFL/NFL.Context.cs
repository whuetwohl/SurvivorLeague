﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class NFLLeagueEntities : DbContext
    {
        public NFLLeagueEntities()
            : base("name=NFLLeagueEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<League> Leagues { get; set; }
        public virtual DbSet<Season> Seasons { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<LeagueSeason> LeagueSeasons { get; set; }
        public virtual DbSet<PlayerSelection> PlayerSelections { get; set; }
        public virtual DbSet<SeasonSchedule> SeasonSchedules { get; set; }
        public virtual DbSet<PlayerLeagueSeason> PlayerLeagueSeasons { get; set; }
    
        public virtual ObjectResult<GetLeagueSeasonWeekMatchups_Result> GetLeagueSeasonWeekMatchups(Nullable<int> leagueId, Nullable<int> seasonId, Nullable<int> week)
        {
            var leagueIdParameter = leagueId.HasValue ?
                new ObjectParameter("LeagueId", leagueId) :
                new ObjectParameter("LeagueId", typeof(int));
    
            var seasonIdParameter = seasonId.HasValue ?
                new ObjectParameter("SeasonId", seasonId) :
                new ObjectParameter("SeasonId", typeof(int));
    
            var weekParameter = week.HasValue ?
                new ObjectParameter("Week", week) :
                new ObjectParameter("Week", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetLeagueSeasonWeekMatchups_Result>("GetLeagueSeasonWeekMatchups", leagueIdParameter, seasonIdParameter, weekParameter);
        }
    
        public virtual ObjectResult<GetPlayerLeagues_Result> GetPlayerLeagues(Nullable<int> playerId)
        {
            var playerIdParameter = playerId.HasValue ?
                new ObjectParameter("PlayerId", playerId) :
                new ObjectParameter("PlayerId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetPlayerLeagues_Result>("GetPlayerLeagues", playerIdParameter);
        }
    
        public virtual ObjectResult<GetPlayerSelections_Result> GetPlayerSelections(Nullable<int> playerId, Nullable<int> leagueId, Nullable<int> seasonId)
        {
            var playerIdParameter = playerId.HasValue ?
                new ObjectParameter("PlayerId", playerId) :
                new ObjectParameter("PlayerId", typeof(int));
    
            var leagueIdParameter = leagueId.HasValue ?
                new ObjectParameter("LeagueId", leagueId) :
                new ObjectParameter("LeagueId", typeof(int));
    
            var seasonIdParameter = seasonId.HasValue ?
                new ObjectParameter("SeasonId", seasonId) :
                new ObjectParameter("SeasonId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetPlayerSelections_Result>("GetPlayerSelections", playerIdParameter, leagueIdParameter, seasonIdParameter);
        }
    }
}
