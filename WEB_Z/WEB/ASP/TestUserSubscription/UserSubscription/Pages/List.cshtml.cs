using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserSubscription.Models;
using UserSubscription.Services;

namespace UserSubscription.Pages
{
    public class ListModel : PageModel
    {
        private ISubscriptionStorage _ss;
        public List<Subscription> Subscriptions { get; set; }

        public ListModel(ISubscriptionStorage ss)
        {
            _ss = ss;
        }

        public void OnGet()
        {
            Subscriptions = _ss.Subscriptions;
        }
    }
}