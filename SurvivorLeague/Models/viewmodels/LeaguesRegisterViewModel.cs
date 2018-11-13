using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SurvivorLeague.Models
{
    public class LeaguesRegisterViewModel
    {
        public int CommissionerPlayerId { get; set; }
        public string CommissionerName { get; set; }
        public string CommissionerEmail { get; set; }
        [DisplayName("League Name")]
        [Required(ErrorMessage = "REQUIRED")]
        public string LeagueName { get; set; }
        [DisplayName("Notes")]
        public string  LeagueNotes { get; set; }
        [DisplayName("Start Week")]
        public int StartWeek { get; set; }
        
        public DateTime LeagueRegistrationDate { get; set; }

        [DisplayName("Invitees")]
        List<Invitee> Invitees{ get; set; }

    }

    class Invitee
    {
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public int NumberOfEntries { get; set; }
    }
}