using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SurvivorLeague.Models;
using SurvivorLeague.NFL;
using SurvivorLeague.MLB;
using System.Data.SqlClient;

namespace SurvivorLeague.Controllers
{
    public class LeaguesController : Controller
    {
        // GET: Leagues
        public ActionResult Index()
        {
            // remove after complete
            if (Session["PlayerId"] == null) return RedirectToAction("Index", "Home");

            int playerId = Convert.ToInt32(Session["PlayerId"]);
            List<PlayerLeagueViewModel> Leagues = new List<PlayerLeagueViewModel>();

            using (NFLLeagueEntities nfl = new NFLLeagueEntities())
            {
                var nflLeagues = nfl.GetPlayerLeagues(playerId);
                foreach (var league in nflLeagues)
                {
                    Leagues.Add(new PlayerLeagueViewModel() { LeagueId = league.ID, LeagueName = league.Name, LeagueType = "NFL", FavoriteTeamColors = nfl.Players.Single(p => p.ID == playerId).FavoriteTeam.Single().Colors });
                }
            }

            //using (MLBLeagueEntities mlb = new MLBLeagueEntities())
            //{
            //    var mlbLeagues = mlb.GetPlayerLeagues(playerId);
            //    foreach (var league in mlbLeagues)
            //    {
            //        Leagues.Add(new PlayerLeagueViewModel() { LeagueId = league.ID, LeagueName = league.Name, LeagueType = "MLB", FavoriteTeamColors = mlb.Players.Single(p => p.ID == playerId).FavoriteTeam.Single().Colors });
            //    }
            //}

            return View(Leagues);
        }
    }
}