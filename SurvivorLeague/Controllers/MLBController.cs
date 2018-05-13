using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SurvivorLeague.MLB;
using SurvivorLeague.Models;

namespace SurvivorLeague.Controllers
{
    public class MLBController : Controller
    {
        // GET: MLB

        public ActionResult League(int LeagueId)
        {
            int playerId = Convert.ToInt32(Session["PlayerId"]);
            MLBLeagueEntities db = new MLBLeagueEntities();

            var Colors = db.Players.SingleOrDefault(p => p.ID == playerId).FavoriteTeam.SingleOrDefault().Colors;
            Session["BackColor"] = Colors.Split('|')[0];
            Session["ForeColor"] = Colors.Split('|')[1];

            League league = null;
            using (MLBLeagueEntities nfl = new MLBLeagueEntities())
            {
                league = nfl.Leagues.First(l => l.ID == LeagueId);

            }

            return View(league);
        }

    }
}