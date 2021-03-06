﻿using System;
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
            return View(Leagues);
        }

        [HttpGet]
        public ActionResult Register()
        {
            if (Session["PlayerId"] == null) return RedirectToAction("Index", "Home");
            var playerId = Convert.ToInt32(Session["PlayerId"]);

            LeaguesRegisterViewModel leagueRegistration = new LeaguesRegisterViewModel();

            using (NFLLeagueEntities nfl = new NFLLeagueEntities())
            {
                var commissioner = (from p in nfl.Players where p.ID == playerId select new { p.ID, p.FirstName, p.LastName, p.Email }).FirstOrDefault();
                
                leagueRegistration.CommissionerPlayerId = commissioner.ID;
                leagueRegistration.CommissionerName = $"{ commissioner.FirstName } { commissioner.LastName[0] }.";
                leagueRegistration.CommissionerEmail = commissioner.Email;
                leagueRegistration.LeagueRegistrationDate = DateTime.Now;

                leagueRegistration.StartWeek = nfl.SeasonSchedules.Where(s => s.DateAndTime > DateTime.Now).Select(i => i.Week).Min();
                leagueRegistration.Invitees = new List<Invitee>() { new Invitee { Name = $"{commissioner.FirstName} {commissioner.LastName}", Email = commissioner.Email, NumberOfEntries = 2 } };
            }

            return View(leagueRegistration);
        }

        [HttpPost]
        public ActionResult Register(LeaguesRegisterViewModel vm)
        {
            using (NFLLeagueEntities nfl = new NFLLeagueEntities())
            {
                if(nfl.Leagues.Where(l => l.Name == vm.LeagueName).Count() > 0)
                {
                    ViewBag.Message = "League Already Exists";
                    return Register();
                }
                else
                {
                    NFL.League league = new NFL.League();
                    league.Name = vm.LeagueName;
                    league.Notes = vm.LeagueNotes;
                    league.CommissionerPlayerID = vm.CommissionerPlayerId;
                    league.Created = vm.LeagueRegistrationDate;
                    nfl.Leagues.Add(league);
                    nfl.SaveChanges();
                    foreach(var invitee in vm.Invitees)
                    {
                        //nfl.LeagueInvitations.Add(new LeagueInvitation() { LeagueId = league.ID, PlayerName = invitee.Name, PlayerEmail = invitee.Email, Date = DateTime.Now });
                    }
                    nfl.SaveChanges();

                }
            }

                return View(vm);
        }

    }
}