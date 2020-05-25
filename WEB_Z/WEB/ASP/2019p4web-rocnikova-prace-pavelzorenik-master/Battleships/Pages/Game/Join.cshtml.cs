using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Battleships.Model;
using Battleships.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Battleships.Pages.Game
{
    [Authorize]
    public class JoinModel : PageModel
    {
        private readonly GameService _gs;
        [TempData]
        public bool JoinedGame { get; set; }

        public JoinModel(GameService gs)
        {
            _gs = gs;
        }

        public IActionResult OnGet(int GameId)
        {
            JoinedGame = _gs.JoinGame(GameId);
            if (JoinedGame)
                return RedirectToPage("Create");
            return RedirectToPage("../Index");
        }
    }
}