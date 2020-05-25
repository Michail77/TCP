using System.Collections.Generic;
using System.Data;
using HadaniCisel2.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HadaniCisel2.Pages
{
    public class Guess : PageModel
    {
        private NumberStorage _ns;
        public Guess(NumberStorage ns)
        {
            _ns = ns;
        }
        public int GuessedNumber { get; set; }
        public List<SelectListItem> AllNumbers { get; set; } = new List<SelectListItem>();
        public void OnGet()
        {
            for (int i = 0; i < _ns.State.Limit+1;i++)
                AllNumbers.Add(new SelectListItem {Value = i.ToString(),Text = i.ToString()});
        }

        public ActionResult OnPost(int GuessedNumber)
        {
            if (ModelState.IsValid)
            {
                return RedirectToPage("Index", new {GuessedNumber = GuessedNumber});
            }

            return Page();
        }
    }
}