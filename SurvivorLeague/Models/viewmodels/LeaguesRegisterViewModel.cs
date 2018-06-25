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
        [DisplayName("Commissioner's Notes")]
        public string  LeagueNotes { get; set; }
        [DisplayName("Week")]
        public int StartWeek { get; set; }
        [DisplayName("Players")]
        public int NumberOfInvitees { get; set; }

        public DateTime LeagueRegistrationDate { get; set; }

        [DisplayName("Invitees")]
        public List<Invitee> Invitees{ get; set; }

    }

    public class Invitee
    {
        [DisplayName("Player Name")]
        public string Name { get; set; }
        [EmailAddress]
        [DisplayName("Player Email")]
        public string Email { get; set; }
        [DisplayName("Qty")]
        public int NumberOfEntries { get; set; }
    }
}