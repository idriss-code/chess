using Microsoft.VisualStudio.TestTools.UnitTesting;
using chessboard.pieces;
using chessboard.enums;
using chessboard;
using chessboard.exceptions;

namespace chessboardTest
{
    [TestClass]
    public class PlayerTest
    {
        [TestMethod]
        [ExpectedException(typeof(ChessBoardException), "Invalid Player")]
        public void NewGameBlackCantMove()
        {
            var chessboard = new Chessboard();
            chessboard.NewGame();
            var blackPawn = chessboard.GetPieceOnSquare("e", "7");
            blackPawn?.Move("e", "6");
        }

        [TestMethod]
        [ExpectedException(typeof(ChessBoardException), "Invalid Player")]
        public void CantMoveTwice()
        {
            var chessboard = new Chessboard();
            chessboard.NewGame();
            var pawn = chessboard.GetPieceOnSquare("e", "2");
            pawn?.Move("e", "3");
            pawn?.Move("e", "4");
        }
    }
}