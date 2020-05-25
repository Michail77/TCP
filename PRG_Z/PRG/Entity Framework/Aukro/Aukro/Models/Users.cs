using System;
using System.Collections.Generic;

namespace Aukro.Models
{
    public partial class Users
    {
        public Users()
        {
            AuctionsSellerUser = new HashSet<Auctions>();
            AuctionsWinnerUser = new HashSet<Auctions>();
        }

        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Auctions> AuctionsSellerUser { get; set; }
        public virtual ICollection<Auctions> AuctionsWinnerUser { get; set; }
    }
}
