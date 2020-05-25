using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Battleships.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Battleships.Pages.Game
{
    [Authorize]
    public class QuitModel : PageModel
    {
        private readonly GameService _gs;
        [TempData]
        public bool? QuitGame { get; set; }

        public QuitModel(GameService gs)
        {
            _gs = gs;
        }

        public IActionResult OnGet()
        {
            QuitGame = _gs.QuitGame();
            return RedirectToPage("../Index");
        }
    }
}