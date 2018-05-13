﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SurvivorLeague.MLB
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class MLBLeagueEntities : DbContext
    {
        public MLBLeagueEntities()
            : base("name=MLBLeagueEntities")
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
        public virtual DbSet<SeasonSchedule> SeasonSchedules { get; set; }
    
        public virtual ObjectResult<GetPlayerLeagues_Result> GetPlayerLeagues(Nullable<int> playerId)
        {
            var playerIdParameter = playerId.HasValue ?
                new ObjectParameter("PlayerId", playerId) :
                new ObjectParameter("PlayerId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetPlayerLeagues_Result>("GetPlayerLeagues", playerIdParameter);
        }
    }
}
