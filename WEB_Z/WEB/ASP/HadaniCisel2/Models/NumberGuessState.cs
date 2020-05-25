using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HadaniCisel2.Models
{
    public class NumberGuessState
    {
        public int Limit { get; set; }
        public int GuessedNumber { get; set; }
        public int Attempt { get; set; }
        public int LastGuess { get; set; }
        public GameState State { get; set; }
    }
}