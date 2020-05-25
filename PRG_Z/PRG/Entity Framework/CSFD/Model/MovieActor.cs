 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CSFD.Model
{
    class MovieActor
    {
        [Required]
        public int ActorId { get; set; }
        [Required]
        public int MovieId { get; set; }
        [Required]
        [ForeignKey("ActorId")]
        public Actor Actor { get; set; }
        [Required]
        [ForeignKey("MovieId")]
        public Movie Movie { get; set; }
    }
}
