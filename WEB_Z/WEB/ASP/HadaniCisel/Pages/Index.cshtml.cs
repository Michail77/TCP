using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;

namespace HadaniCisel.Pages
{
    public class IndexModel : PageModel
    {
        [Required]
        [Display(Name = "Od")]
        public int? From { get; set; }
        [Required]
        [Display(Name = "Do")]
        public int? To { get; set; }
        public int? RandomNumber { get; set; }
        public string Error { get; set; }
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        
        public void OnGet()
        {
            Error = "";
            From = 0;
            To = 10;
        }
        public void OnPost(int? From,int? To)
        {
            if (From != null && To != null && ModelState.IsValid)
            {
                if (From == To)
                    Error = "Od a do se musí lišit alespoň o jedno číslo.";
                else
                {
                    Random rand = new Random((int)DateTime.Now.Ticks);
                    if (To < From)
                        RandomNumber = rand.Next((int) To, (int) From);
                    else
                        RandomNumber = rand.Next((int) From, (int) To);
                    Response.Cookies.Delete("a");
                    Response.Cookies.Append("a",RandomNumber.ToString());  
                    Response.Redirect("Set");
                    Error = "";
                }
            }
            else
            {
                if (From == null)
                    Error = "Zadejte od. ";
                if (To == null)
                    Error += "Zadejte do.";
            }
        }
    }
}