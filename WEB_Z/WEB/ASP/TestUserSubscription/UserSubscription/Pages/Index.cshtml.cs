using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UserSubscription.Pages
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string SuccessMessage { get; set; }
        [TempData]
        public string FailureMessage { get; set; }
        public void OnGet()
        {

        }
    }
}
