using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using UserSubscription.Models;
using UserSubscription.Services;

namespace UserSubscription.Pages
{
    public class SubscriptionModel : PageModel
    {
        private ISubscriptionStorage _ss;
        private CountriesProvider _cp;

        public List<SelectListItem> CountriesList { get; } = new List<SelectListItem>();
        [BindProperty]
        public Subscription Input { get; set; }
        [TempData]
        public string SuccessMessage { get; set; }
        [TempData]
        public string FailureMessage { get; set; }

        public SubscriptionModel(ISubscriptionStorage ss, CountriesProvider cp)
        {
            _ss = ss;
            _cp = cp;
            foreach (KeyValuePair<string, string> country in _cp.EUMembers)
            {
                CountriesList.Add(new SelectListItem(country.Value, country.Key));
            }
            foreach (KeyValuePair<string, string> country in _cp.EFTA)
            {
                CountriesList.Add(new SelectListItem(country.Value, country.Key));
            }
        }

        public void OnGet()
        {
            
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _ss.Add(Input);
                SuccessMessage = "Registrace se podařila.";
                return RedirectToPage("Index");
            }
            FailureMessage = "Registrace se nepodařila.";
            return Page();
        }
    }
}