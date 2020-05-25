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
    public class CreateModel : PageModel
    {
        private readonly GameService _gs;
        [TempData]
        public bool? CreatedGame { get; set; }
        [TempData]
        public bool? JoinedGame { get; set; }
        [TempData]
        public bool? StartedGame { get; set; }
        public PlayerState PlayerState;
        public List<Ship2> Ships { get; set; }
        public int BoardSize { get; set; }

        public CreateModel(GameService gs)
        {
            _gs = gs;
            Ships = new List<Ship2>()
            {
                new Ship2() { Name = "Submarine", Length = 1, Count = 2 },
                new Ship2() { Name = "Destroyer", Length = 2, Count = 2 },
                new Ship2() { Name = "Cruiser", Length = 3, Count = 1 },
                new Ship2() { Name = "Battleship", Length = 4, Count = 1 },
                new Ship2() { Name = "Aircraft carrier", Length = 5, Count = 1 }
            };
            BoardSize = 10;
        }

        public void OnGet()
        {
            PlayerState = _gs.GetPlayerState();
        }

        public IActionResult OnGetTryCreate()
        {
            CreatedGame = _gs.CreateGame();
            return RedirectToPage();
        }

        public IActionResult OnGetTryStart()
        {
            StartedGame = _gs.StartGame(BoardSize, Ships);
            if ((bool)StartedGame)
                return RedirectToPage("Play");
            return RedirectToPage();
        }
    }
}