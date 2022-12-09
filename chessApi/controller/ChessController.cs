using chessApi.model;
using chessboard;
using chessboard.pieces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace chessApi.controller
{
    [Route("api/chess")]
    public class ChessController : Controller
    {
        List<Chessboard> chessboards = new List<Chessboard>();

        // GET: 
        [HttpGet("createGame")]
        public IActionResult CreateGame()
        {

            Chessboard chessbaord = new Chessboard();
            chessbaord.NewGame();
            chessboards.Add(chessbaord);
            return Content($"{chessboards.Count - 1}");
        }

        // GET: 
        [HttpGet("movePiece")]
        public IActionResult MovePiece(int chessboard, string startCol, string startRow, string endCol, string endRow)
        {
            try
            {
                Chessboard chessbaord = chessboards[chessboard];
                IPiece piece = chessbaord.GetPieceOnSquare(startCol, startRow);
                piece.Move(endCol, endRow);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }

        }
    }
}
