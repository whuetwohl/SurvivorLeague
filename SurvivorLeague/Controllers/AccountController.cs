using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using SurvivorLeague.Models;
using System.Web.Helpers;
using SurvivorLeague.BusinessLogic;

namespace SurvivorLeague.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return RedirectToAction("Login");
        }

        #region Registration
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(AccountRegistrationViewModel vm)
        {

            if(ModelState.IsValid)
            {
                using (SurvivorLeagueEntities db = new SurvivorLeagueEntities())
                {
                    if(db.Players.Count(p=>p.Email == vm.Email) > 0)
                    {
                        ModelState.AddModelError("", "Email already exists");
                        return View();
                    }
                    Player player = new Player() { FirstName = vm.FirstName, LastName = vm.LastName, DateOfBirth = vm.DateOfBirth, Email = vm.Email, Password = Crypto.Hash(vm.Password), RegisteredDate = DateTime.Now, ConfirmationCode = Crypto.Hash(vm.Email) };
                    db.Players.Add(player);
                    try
                    {
                        db.SaveChanges();
                        Email.SendConfirmationEmail(player, Session["Domain"].ToString());
                    }
                    catch (System.Data.Entity.Validation.DbEntityValidationException ex)
                    {
                        foreach (var entityValidationErrors in ex.EntityValidationErrors)
                        {
                            foreach (var validationError in entityValidationErrors.ValidationErrors)
                            {
                                Response.Write("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                            }
                        }
                    }
                    int playerId = player.ID;
                    //db.Players.Add(player);
                    //db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = string.Format("{0} account Created.  You will receive a confirmation email", vm.Email);
                return Redirect("Login");
            }
            return View();
        }
        #endregion

        #region Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AccountLoginViewModel player)
        {
            using (SurvivorLeagueEntities db = new SurvivorLeagueEntities())
            {
                var user = db.Players.Where(m => m.Email == player.Email).FirstOrDefault();
                if(user != null && Crypto.Hash(player.Password) == user.Password)
                {
                    Session["PlayerId"] = user.ID;
                    Session["PlayerName"] = string.Format("{0} {1}", user.FirstName, user.LastName);
                    return RedirectToAction("Index", "Leagues");
                }
                else
                {
                    ModelState.AddModelError("", "Email or Password is incorrect");
                }
                
            }
            return View();
        }
        #endregion

        public ActionResult Confirm(string Code)
        {
            if(string.IsNullOrEmpty(Code))
            {
                ViewBag.Message = "Invalid Code";
                return RedirectToAction("Error", "Home");
            }
            else
            {
                using (SurvivorLeagueEntities db = new SurvivorLeagueEntities())
                {
                    Player player = db.Players.Where(p=>p.ConfirmationCode == Code).First();
                    player.ConfirmationCode = string.Format("Confirmed On {0}", DateTime.Now.ToString());
                    player.Confirmed = true;
                    db.SaveChanges();
                }
                ViewBag.Message = "Account Confirmed";
                return View();
            }
        }

        public ActionResult SignOut()
        {
            Session["PlayerId"] = null;
            Session["PlayerName"] = null;
            //Session["ForeColor"] = null;
            //Session["BackColor"] = null;
            return RedirectToAction("Index", "Home");
        }

    }
}