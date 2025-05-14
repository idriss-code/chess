using chessboard;
using chessboard.interfaces;
using chessboard.pieces;
using Microsoft.AspNetCore.Mvc;

namespace chessApi.Controllers
{
    [Route("api/chess")]
    [ApiController]
    public class ChessGamesController : Controller
    {
        private readonly IGameStateRepository _repository;

        public ChessGamesController(IGameStateRepository repository)
        {
            _repository = repository;
        }

        // POST: api/chess/new-game
        [HttpPost("new-game")]
        public ActionResult<int> SaveGame()
        {
            // Crée une nouvelle partie
            var chessboard = new Chessboard();
            chessboard.NewGame();

            // Sauvegarde la partie
            int gameId = chessboard.Save(_repository);

            return Ok(gameId);
        }

        // GET: api/chess/5
        [HttpGet("{id}")]
        public ActionResult<Chessboard> GetGame(int id)
        {
            try
            {
                var chessboard = Chessboard.Load(id, _repository);
                return Ok(chessboard);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST:  api/chess/move-piece
        [HttpPost("move-piece")]
        public IActionResult MovePiece(int gameId, string startCol, string startRow, string endCol, string endRow)
        {
            try
            {
                var chessboard = Chessboard.Load(gameId, _repository);
                IPiece? piece = chessboard.GetPieceOnSquare(startCol, startRow);
                if (piece is not null)
                {
                    piece.Move(endCol, endRow);
                    chessboard.Save(_repository, gameId);
                    return Ok(chessboard);
                }
                return BadRequest(chessboard);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
    }
}
