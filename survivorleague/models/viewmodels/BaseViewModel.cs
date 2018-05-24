using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurvivorLeague.Models
{
    public abstract class BaseViewModel
    {
        public int PlayerId { get; protected set; }
        public string PlayerName { get; protected set; }

        public BaseViewModel()
        {
            PlayerId = -1;
            PlayerName = "-1";
        }

        public BaseViewModel(int playerId, string playerName)
        {
            PlayerId = PlayerId;
            PlayerName = PlayerName;
        }
    }
}