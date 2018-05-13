using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SurvivorLeague.NFL;
using SurvivorLeague.MLB;

namespace SurvivorLeague.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (NFLLeagueEntities nfl = new NFLLeagueEntities())
            {
                var colors = nfl.Teams.Where(champ => champ.Location == "Philadelphia").FirstOrDefault().Colors;
                Session["BackColor"] = colors.Split('|')[1];
                Session["ForeColor"] = colors.Split('|')[0];
            }
            Session["Domain"] = "10.0.1.79/SurvivorLeague";
            return View();
        }


        public ActionResult Test()
        {
            return View(DateTime.Now);
        }
    }
}