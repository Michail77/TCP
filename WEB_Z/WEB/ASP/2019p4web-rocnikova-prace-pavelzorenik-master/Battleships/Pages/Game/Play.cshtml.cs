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
    public class PlayModel : PageModel
    {
        private readonly GameService _gs;
        public GameState GameState { get; set; }
        public IList<Ship> Ships { get; set; }
        public IList<BoardPiece> BoardPieces { get; set; }
        public int BoardSize { get; set; }
        [TempData]
        public int SelectedShipId { get; set; }
        [TempData]
        public bool? PlacedShip { get; set; }
        [TempData]
        public bool? RemovedShip { get; set; }
        [TempData]
        public bool Reversed { get; set; }

        public PlayModel(GameService gs)
        {
            _gs = gs;
            GameState = _gs.GetGameState();
            Ships = _gs.GetShips();
            BoardPieces = _gs.GetBoardPieces();
            BoardSize = _gs.GetBoardSize();
        }

        public void OnGet()
        {

        }

        public IActionResult OnGetSelectShip(int ShipId, bool Reversed)
        {
            SelectedShipId = ShipId;
            this.Reversed = Reversed;
            return RedirectToPage();
        }

        public IActionResult OnGetPlaceShip(int X, int Y, int ShipId, bool Reversed)
        {
            Console.WriteLine(Reversed);
            PlacedShip = _gs.TryPlaceShip(X-1, Y-1, ShipId, Reversed);
            return RedirectToPage();
        }

        public IActionResult OnGetRemoveShip(int ShipId)
        {
            RemovedShip = _gs.TryRemoveShip(ShipId);
            return RedirectToPage();
        }
    }
}