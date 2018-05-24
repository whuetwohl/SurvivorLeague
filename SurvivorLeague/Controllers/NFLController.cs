using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SurvivorLeague.NFL;
using SurvivorLeague.Models;

namespace SurvivorLeague.Controllers
{
    public class NFLController : Controller
    {
        // GET: NFL
        public ActionResult Index()
        {
            // remove after complete
            if (Session["PlayerId"] == null) return RedirectToAction("Index", "Home");

            SetColors();
            return View();
        }

        public ActionResult League(int LeagueId, int Season)
        {
            // remove after complete
            if (Session["PlayerId"] == null) return RedirectToAction("Index", "Home");

            SetColors();
            int playerId = Convert.ToInt32(Session["PlayerId"]);

            // TODO: Year will be implemented later
            //int seasonId = DateTime.Now.Year;

            List<PlayerSelectionViewModel> Selections = new List<PlayerSelectionViewModel>();
            using (NFLLeagueEntities nfl = new NFLLeagueEntities())
            {
                int SeasonId = nfl.Seasons.Where(s => s.Year == Season).Select(s => s.ID).FirstOrDefault();
                foreach (var selection in nfl.GetPlayerSelections(playerId, LeagueId, SeasonId))
                {
                    string TeamName = selection.SelectedTeamId == null ? "" : nfl.Teams.Where(t => t.ID == selection.SelectedTeamId).First().Name;
                    Selections.Add(new PlayerSelectionViewModel(LeagueId, SeasonId, selection.Week, selection.SelectedTeamId, TeamName, nfl.Teams.First(t => t.ID == selection.SelectedTeamId).Colors));
                }
                ViewBag.Header = nfl.Leagues.First(l => l.ID == LeagueId).Name + " - " + nfl.Players.First(p => p.ID == playerId).FirstName;
            }

            return View(Selections);
        }

        public ActionResult WeeklyMatchups(int LeagueId, int SeasonId, int Week)
        {
            // remove after complete
            if (Session["PlayerId"] == null) return RedirectToAction("Index", "Home");

            SetColors();
            int playerId = Convert.ToInt32(Session["PlayerId"]);

            WeeklyMatchupsViewModel WeeklyMatchups = new WeeklyMatchupsViewModel();

            using (NFLLeagueEntities nfl = new NFLLeagueEntities())
            {
                var results = nfl.GetLeagueSeasonWeekMatchups(LeagueId, SeasonId, Week).ToList();
                var selectedTeams = (from sel in nfl.PlayerSelections
                                     where sel.PlayerId == playerId && sel.LeagueId == LeagueId && sel.SeasonId == SeasonId
                                     select new SelectedTeam() { Week = sel.Week, TeamId = (int)sel.SelectedTeamId }).ToList();

                List<PlayerWeekMatchupViewModel> matchups = new List<PlayerWeekMatchupViewModel>();
                foreach (var matchup in results)
                {
                    DateTime dateTime = new DateTime(matchup.Date.Year, matchup.Date.Month, matchup.Date.Day, matchup.Time.Hours, matchup.Time.Minutes, 0);
                    matchups.Add(new PlayerWeekMatchupViewModel(nfl, dateTime, matchup.VisitorTeamId, matchup.HomeTeamId));
                }

                WeeklyMatchups.Matchups = matchups;
                WeeklyMatchups.SelectedTeams = selectedTeams;
                WeeklyMatchups.LeagueName = nfl.Leagues.FirstOrDefault(l => l.ID == LeagueId).Name;
                WeeklyMatchups.Week = Week;
                WeeklyMatchups.LeagueId = LeagueId;
                WeeklyMatchups.SeasonId = SeasonId;
            }
            return View(WeeklyMatchups);
        }

        [HttpPost]
        //public ActionResult UpdatePick(int LeagueId, int SeasonId, int Week, int TeamId)
        public ActionResult UpdatePick(UpdatePick pick)
        {
            //if (Session["PlayerId"] == null) return RedirectToAction("Index", "Home");

            int playerId = Convert.ToInt32(Session["PlayerId"]);
            using (NFLLeagueEntities nfl = new NFLLeagueEntities())
            {
                if(nfl.PlayerSelections.Count(ps => ps.PlayerId == playerId && ps.LeagueId == pick.LeagueId && ps.SeasonId == pick.SeasonId && ps.SelectedTeamId == pick.TeamId)>0)
                {
                    nfl.PlayerSelections.Remove(nfl.PlayerSelections.SingleOrDefault(ps => ps.PlayerId == playerId && ps.LeagueId == pick.LeagueId && ps.SeasonId == pick.SeasonId && ps.SelectedTeamId == pick.TeamId));
                    nfl.SaveChanges();
                }

                var playerSelection = nfl.PlayerSelections.Where(ps => ps.PlayerId == playerId && ps.LeagueId == pick.LeagueId && ps.SeasonId == pick.SeasonId && ps.Week == pick.Week).FirstOrDefault();
                if(playerSelection != null)
                {
                    playerSelection.SelectedTeamId = pick.TeamId;
                }
                else
                {
                    playerSelection = new PlayerSelection() { LeagueId = pick.LeagueId, SeasonId = pick.SeasonId, PlayerId = playerId, Week = pick.Week, SelectedTeamId = pick.TeamId };
                    nfl.PlayerSelections.Add(playerSelection);
                }
                nfl.SaveChanges();
            }


                return RedirectToAction("WeeklyMatchups", new { pick.LeagueId, pick.SeasonId, pick.Week });
        }

        public void SetColors()
        {
            NFLLeagueEntities nfl = new NFLLeagueEntities();
            var PlayerId = Convert.ToInt32(Session["PlayerId"]);

            var Colors = nfl.Players.SingleOrDefault(p => p.ID == PlayerId).FavoriteTeam.SingleOrDefault().Colors;
            Session["BackColor"] = Colors.Split('|')[0];
            Session["ForeColor"] = Colors.Split('|')[1];
        }

    }
}