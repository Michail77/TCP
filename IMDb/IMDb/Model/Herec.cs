using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IMDb.Model
{
    class Herec
    {
        public int Id { get; set; }
        [Required]
        public string Jmeno { get; set; }
        [Required]
        public string Prijmeni { get; set; }

        public ICollection<HerecFilm> HerecFilmy { get; set; }

    }
}
