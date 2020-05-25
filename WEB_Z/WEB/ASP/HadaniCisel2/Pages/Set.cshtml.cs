using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HadaniCisel2.Services;

namespace HadaniCisel2.Pages
{
    public class SetModel : PageModel
    {
        [BindProperty]
        public int Number { get; set; }
        [TempData]
        public string SuccessMessage { get; set; }
        [TempData]
        public string ErrorMessage { get; set; }
        private NumberStorage _ns;

        public SetModel(NumberStorage ns)
        {
            _ns = ns;
        }

        public void OnGet()
        {
            Number = _ns.State.GuessedNumber;
        }

        public ActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Number <= _ns.State.Limit)
                {
                    _ns.State.GuessedNumber = Number;
                    SuccessMessage = "Succes";
                    return RedirectToPage("Index");
                }
                ErrorMessage = "Error 2";
                return Page();
            }
            ErrorMessage = "Error";
            return Page();
        }
    }
}