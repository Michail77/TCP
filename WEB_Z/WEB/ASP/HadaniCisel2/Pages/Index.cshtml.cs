using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HadaniCisel2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HadaniCisel2.Services;

namespace HadaniCisel2.Pages
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string SuccessMessage { get; set; }
        private NumberStorage _ns;

        public IndexModel(NumberStorage ns)
        {
            _ns = ns;
        }

        public NumberGuessState State { get; set; }
        public string Result { get; set; } = "";

        public void OnGet(int? GuessedNumber = null)
        {
            if (GuessedNumber != null)
            {
                switch (_ns.Guess((int)GuessedNumber))
                {
                    case -1:
                        Result = "Menší";
                        break;
                    case 1:
                        Result = "Větší";
                        break;
                }
            }
            State = _ns.State;
        }

        public ActionResult OnGetRestart()
        {
            _ns.Restart();
            return RedirectToPage("Index");
        }
    }
}