using System.Net;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace HadaniCisel.Pages
{
    public class Set : PageModel
    {
        [Required]
        [Display(Name = "Číslo")]
        public int? Number { get; set; }
        private int RandomNumber { get; set; }
        public string Error { get; private set; }
        public string Text { get; private set; }
        public void OnGet()
        {
            RandomNumber = int.Parse(HttpContext.Request.Cookies["a"]);
            Error = "";
        }
        public void OnPost(int? Number)
        {
            RandomNumber = int.Parse(HttpContext.Request.Cookies["a"]);
            if (Number != null && ModelState.IsValid)
            {
                Error = "";
                if (Number == RandomNumber)
                    Text = "Výhra";
                else if (Number > RandomNumber)
                    Text = "Menší";
                else
                    Text = "Větší";
            }

            else if (Number == null)
                Error = "Zadejte hádané číslo.";
        }
    }
}