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
            //using (NFLLeagueEntities nfl = new NFLLeagueEntities())
            //{
            //    var colors = nfl.Teams.Where(champ => champ.Location == "Philadelphia").FirstOrDefault().Colors;
            //    Session["BackColor"] = colors.Split('|')[1];
            //    Session["ForeColor"] = colors.Split('|')[0];
            //}
            var ipAddress = System.Net.Dns.GetHostAddresses(System.Net.Dns.GetHostName())
                                .Where(i => !i.IsIPv6LinkLocal).FirstOrDefault();
            var hostName = System.Net.Dns.GetHostName();

            Session["Domain"] = $"{ ipAddress }/SurvivorLeague";
            return View();
        }


        public ActionResult Test()
        {
            return View(DateTime.Now);
        }
    }
}