using System;
using System.Collections.Generic;

namespace Aukro.Models
{
    public partial class Auctions
    {
        public int AuctionId { get; set; }
        public int CurrentPrice { get; set; }
        public int? BuyNowPrice { get; set; }
        public int EndTime { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsEnd { get; set; }
        public int? WinnerUserId { get; set; }
        public int SellerUserId { get; set; }

        public virtual Users SellerUser { get; set; }
        public virtual Users WinnerUser { get; set; }
    }
}
