using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Battleships.Model
{
    public enum GameState
    {
        WaitingForPlayers,
        WaitingForStart,
        PlacingShips,
        Battle,
        End
    }

    public class Game
    {
        [Key]
        public int Id { get; set; }
        public int BoardSize { get; set; }
        public GameState State { get; set; }

        public string Player1Id { get; set; }
        [ForeignKey("Player1Id")]
        public Player Player1 { get; set; }

        public string Player2Id { get; set; }
        [ForeignKey("Player2Id")]
        public Player Player2 { get; set; }

        public string CurrentPlayerId { get; set; }
        [ForeignKey("CurrentPlayerId")]
        public Player CurrentPlayer { get; set; }

        public string WinnerId { get; set; }
        [ForeignKey("WinnerId")]
        public Player Winner { get; set; }
    }
}
