using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Battleships.Model;
using Battleships.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Battleships.Pages
{
    public class IndexModel : PageModel
    {
        private readonly GameService _gs;
        public IList<Model.Game> JoinableGames;
        public PlayerState PlayerState;
        [TempData]
        public bool? QuitGame { get; set; }
        [TempData]
        public bool? JoinedGame { get; set; }

        public IndexModel(GameService gs)
        {
            _gs = gs;
        }

        public void OnGet()
        {
            if (User.Identity.IsAuthenticated)
            {
                JoinableGames = _gs.GetJoinableGames();
                PlayerState = _gs.GetPlayerState();
            }
        }
    }
}
