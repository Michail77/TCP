using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IMDb.Model
{
    class HerecFilm
    {
        [Required]
        public int HerecId { get; set; }
        [Required]
        public int FilmId { get; set; }
        [Required]
        [ForeignKey("HerecId")]
        public Herec Herec { get; set; }
        [Required]
        [ForeignKey("MovieId")]
        public Film Film { get; set; }
    }
}
