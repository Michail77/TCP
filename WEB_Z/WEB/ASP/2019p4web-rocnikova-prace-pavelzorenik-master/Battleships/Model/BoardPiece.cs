using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Battleships.Model
{
    public class BoardPiece
    {
        [Key]
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsHit { get; set; }

        public int PlayerGameId { get; set; }
        [ForeignKey("PlayerGameId")]
        public PlayerGame PlayerGame { get; set; }

        public int? ShipId { get; set; }
        [ForeignKey("ShipId")]
        public Ship Ship { get; set; }
    }
}
