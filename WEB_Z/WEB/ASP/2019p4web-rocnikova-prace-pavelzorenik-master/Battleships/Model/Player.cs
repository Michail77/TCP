using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Battleships.Model
{
    public enum PlayerState
    {
        NotInGame,
        WaitingForPlayer,
        WaitingForStart,
        ReadyToStart,
        InGame
    }

    public class Player : IdentityUser
    {
        public PlayerState State { get; set; }
        public int? CurrentPlayerGameId { get; set; }
        [ForeignKey("CurrentPlayerGameId")]
        public PlayerGame CurrentPlayerGame { get; set; }
    }
}
