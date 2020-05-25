using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IMDb.Model
{
    class Film
    {
        public int Id { get; set; }
        [Required]
        public string Nazev { get; set; }
        [Required]
        public int Hodnoceni { get; set; }

        public ICollection<HerecFilm> HerecFilmy { get; set; }
    }
}
