using Battleships.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Battleships.Services
{
    [Authorize]
    public class GameService
    {
        private readonly ApplicationDbContext _db;
        private readonly IHttpContextAccessor _hca;
        private PlayerGame player_game;
        private Player player;
        private Game game;

        public GameService(ApplicationDbContext db, IHttpContextAccessor hca)
        {
            _db = db;
            _hca = hca;
        }

        public bool CreateGame()
        {
            player = GetLoggedInUser();
            if (player.State == PlayerState.NotInGame)
            {
                player.State = PlayerState.WaitingForPlayer;
                _db.SaveChanges();
                game = new Game() { Player1Id = player.Id, Player1 = player, State = GameState.WaitingForPlayers };
                _db.Games.Add(game);
                _db.SaveChanges();
                player_game = new PlayerGame() { GameId = game.Id, Game = game, PlayerId = player.Id, Player = player };
                _db.PlayerGames.Add(player_game);
                _db.SaveChanges();
                player.CurrentPlayerGameId = player_game.Id;
                player.CurrentPlayerGame = player_game;
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool JoinGame(int game_id)
        {
            player = GetLoggedInUser();
            if (player.State == PlayerState.NotInGame)
            {
                game = _db.Games.Where(g => g.Id == game_id).FirstOrDefault();
                if (game != null && game.Player2Id == null && game.Player1Id != player.Id)
                {
                    GetPlayer(game.Player1Id).State = PlayerState.ReadyToStart;
                    player.State = PlayerState.WaitingForStart;
                    game.Player2Id = player.Id;
                    game.Player2 = player;
                    game.State = GameState.WaitingForStart;
                    player_game = new PlayerGame() { GameId = game.Id, Game = game, PlayerId = player.Id, Player = player };
                    _db.PlayerGames.Add(player_game);
                    _db.SaveChanges();
                    player.CurrentPlayerGameId = player_game.Id;
                    player.CurrentPlayerGame = player_game;
                    _db.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public bool QuitGame()
        {
            player = GetLoggedInUser();
            game = _db.Games.Where(g => g.State != GameState.End && (g.Player1Id == player.Id || g.Player2Id == player.Id)).FirstOrDefault();
            if (game != null)
            {
                game.State = GameState.End;
                player.State = PlayerState.NotInGame;
                player.CurrentPlayerGameId = null;
                if (game.Player2Id != null)
                {
                    Player player2 = GetPlayer(game.Player2Id);
                    player2.State = PlayerState.NotInGame;
                    player.CurrentPlayerGameId = null;
                    if (game.Player1Id == player.Id)
                    {
                        game.WinnerId = game.Player2Id;
                        game.Winner = game.Player2;
                    }
                    else
                    {
                        game.WinnerId = game.Player1Id;
                        game.Winner = game.Player1;
                    }
                }
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool StartGame(int board_size, List<Ship2> ships)
        {
            player = GetLoggedInUser();
            game = _db.Games.Where(g => g.Player1Id == player.Id && g.State == GameState.WaitingForStart).FirstOrDefault();
            PlayerGame player_game1 = _db.PlayerGames.Where(pg => pg.GameId == game.Id && pg.PlayerId == game.Player1Id).FirstOrDefault();
            PlayerGame player_game2 = _db.PlayerGames.Where(pg => pg.GameId == game.Id && pg.PlayerId == game.Player2Id).FirstOrDefault();
            Player player2 = GetPlayer(game.Player2Id);
            if (game != null)
            {
                player.State = player2.State = PlayerState.InGame;
                game.State = GameState.PlacingShips;
                game.BoardSize = board_size;
                foreach (Ship2 ship in ships)
                {
                    for (int i = 0; i < ship.Count; i++)
                    {
                        _db.Ships.Add(new Ship() { Name = ship.Name, Length = ship.Length, Lives = ship.Length, IsDestroyed = false, PlayerGameId = player_game1.Id, PlayerGame = player_game1, IsPlaced = false });
                        _db.Ships.Add(new Ship() { Name = ship.Name, Length = ship.Length, Lives = ship.Length, IsDestroyed = false, PlayerGameId = player_game2.Id, PlayerGame = player_game2, IsPlaced = false });
                    }
                    _db.SaveChanges();
                }
                for (int i = 0; i < board_size; i++)
                {
                    for (int j = 0; j < board_size; j++)
                    {
                        _db.BoardPieces.Add(new BoardPiece() { X = i, Y = j, PlayerGameId = player_game1.Id, PlayerGame = player_game1, IsHit = false });
                        _db.BoardPieces.Add(new BoardPiece() { X = i, Y = j, PlayerGameId = player_game2.Id, PlayerGame = player_game2, IsHit = false });
                    }
                    _db.SaveChanges();
                }
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool TryPlaceShip(int x, int y, int ship_id, bool reversed)
        {
            player = GetLoggedInUser();
            player_game = _db.PlayerGames.Where(pg => pg.Id == player.CurrentPlayerGameId).FirstOrDefault();
            Ship ship = _db.Ships.Where(s => s.Id == ship_id).FirstOrDefault();
            if (ship == null || player_game == null || ship.IsPlaced)
                return false;
            if (!reversed)
            {
                for (int i = y; i < y + ship.Length; i++)
                    if (_db.BoardPieces.Where(bp => bp.PlayerGameId == player_game.Id && bp.X == x && bp.Y == i && bp.ShipId == null).FirstOrDefault() == null)
                        return false;
                for (int i = y; i < y + ship.Length; i++)
                    _db.BoardPieces.Where(bp => bp.PlayerGameId == player_game.Id && bp.X == x && bp.Y == i).FirstOrDefault().ShipId = ship_id;
            }
            else
            {
                for (int i = x; i < x + ship.Length; i++)
                    if (_db.BoardPieces.Where(bp => bp.PlayerGameId == player_game.Id && bp.X == i && bp.Y == y && bp.ShipId == null).FirstOrDefault() == null)
                        return false;
                for (int i = x; i < x + ship.Length; i++)
                    _db.BoardPieces.Where(bp => bp.PlayerGameId == player_game.Id && bp.X == i && bp.Y == y).FirstOrDefault().ShipId = ship_id;
            }
            ship.IsPlaced = true;
            _db.SaveChanges();
            return true;
        }
        public bool TryRemoveShip(int ship_id)
        {
            player = GetLoggedInUser();
            player_game = _db.PlayerGames.Where(pg => pg.Id == player.CurrentPlayerGameId).FirstOrDefault();
            Ship ship = _db.Ships.Where(s => s.Id == ship_id).FirstOrDefault();
            if (ship == null || player_game == null || !ship.IsPlaced)
                return false;
            if (_db.BoardPieces.Where(bp => bp.PlayerGameId == player_game.Id && bp.ShipId == ship_id).FirstOrDefault() == null)
                return false;
            foreach (BoardPiece bp in _db.BoardPieces.Where(bp => bp.PlayerGameId == player_game.Id && bp.ShipId == ship_id))
                bp.ShipId = null;
            ship.IsPlaced = false;
            _db.SaveChanges();
            return true;
        }

        public Player GetLoggedInUser()
        {
            string userId = _hca.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return _db.Users.Where(u => u.Id == userId).FirstOrDefault();
        }

        public Player GetPlayer(string player_id)
        {
            return _db.Users.Where(u => u.Id == player_id).FirstOrDefault();
        }

        public PlayerState GetPlayerState()
        {
            player = GetLoggedInUser();
            return player.State;
        }

        public GameState GetGameState()
        {
            player = GetLoggedInUser();
            return GetGame(player).State;
        }

        public Game GetGame(Player player)
        {
            player_game = _db.PlayerGames.Where(pg => pg.Id == player.CurrentPlayerGameId).FirstOrDefault();
            return _db.Games.Where(g => g.Id == player_game.GameId).FirstOrDefault();
        }

        public IList<Game> GetJoinableGames()
        {
            player = GetLoggedInUser();
            return _db.Games.Where(g => g.State == GameState.WaitingForPlayers && g.Player1.Id != player.Id).ToList();
        }

        public IList<Ship> GetShips()
        {
            player = GetLoggedInUser();
            return _db.Ships.Where(s => s.PlayerGameId == player.CurrentPlayerGameId).ToList();
        }

        public IList<BoardPiece> GetBoardPieces()
        {
            player = GetLoggedInUser();
            return _db.BoardPieces.Where(bp => bp.PlayerGameId == player.CurrentPlayerGameId).OrderBy(bp => bp.X).ThenBy(bp => bp.Y).ToList();
        }

        public int GetBoardSize()
        {
            player = GetLoggedInUser();
            return GetGame(player).BoardSize;
        }
    }
}
