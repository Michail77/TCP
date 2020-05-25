using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Battleships.Model
{
    public class Ship
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Length { get; set; }
        public int Lives { get; set; }
        public bool IsDestroyed { get; set; }
        public bool IsPlaced { get; set; }

        public int PlayerGameId { get; set; }
        [ForeignKey("PlayerGameId")]
        public PlayerGame PlayerGame { get; set; }
    }

    public class Ship2
    {
        public string Name { get; set; }
        public int Length { get; set; }
        public int Count { get; set; }
    }
}
