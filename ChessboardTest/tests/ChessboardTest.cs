using Microsoft.VisualStudio.TestTools.UnitTesting;
using chessboard;
using chessboard.pieces;
using chessboard.exceptions;

namespace chessboardTest
{
    [TestClass]
    public class ChessboardTest
    {
        [TestMethod]
        public void ChessboardCreation()
        {
            var chessboard = new Chessboard();
            Assert.IsNotNull(chessboard);
        }

        [TestMethod]
        public void GameCreation()
        {
            var chessboard = new Chessboard();
            chessboard.NewGame();

            var whiteRook1 = chessboard.GetSquare("a", "1");
            Assert.IsTrue(whiteRook1 is Rook);
            var whiteKnight1 = chessboard.GetSquare("b", "1");
            Assert.IsTrue(whiteKnight1 is Knight);
            var whiteBishop1 = chessboard.GetSquare("c", "1");
            Assert.IsTrue(whiteBishop1 is Bishop);
            var whiteQueen = chessboard.GetSquare("d", "1");
            Assert.IsTrue(whiteQueen is Queen);
            var whiteKing = chessboard.GetSquare("e", "1");
            Assert.IsTrue(whiteKing is King);
            var whiteBishop2 = chessboard.GetSquare("f", "1");
            Assert.IsTrue(whiteBishop2 is Bishop);
            var whiteKnight2 = chessboard.GetSquare("g", "1");
            Assert.IsTrue(whiteKnight2 is Knight);
            var whiteRook2 = chessboard.GetSquare("h", "1");
            Assert.IsTrue(whiteRook2 is Rook);
        }

        [TestMethod]
        public void AddPiece()
        {
            var chessboard = new Chessboard();
            chessboard.AddPiece(new King("a","1"));
            var king = chessboard.GetSquare("a", "1");
            Assert.IsTrue(king is King);
        }

        [TestMethod]
        [ExpectedException(typeof(ChessBoardException), "Invalid square")]
        public void AddPieceOutside()
        {
            var chessboard = new Chessboard();
            chessboard.AddPiece(new King("", ""));
        }

        [TestMethod]
        [ExpectedException(typeof(ChessBoardException), "Invalid square")]
        public void AddPieceOutsideRow()
        {
            var chessboard = new Chessboard();
            chessboard.AddPiece(new King("a", ""));
        }

        [TestMethod]
        [ExpectedException(typeof(ChessBoardException), "Invalid square")]
        public void AddPieceOutsideCol()
        {
            var chessboard = new Chessboard();
            chessboard.AddPiece(new King("", "1"));
        }

        [TestMethod]
        [ExpectedException(typeof(ChessBoardException), "2 pieces same square")]
        public void AddPiece2PieceSameSquare()
        {
            var chessboard = new Chessboard();
            chessboard.AddPiece(new King("a", "1"));
            chessboard.AddPiece(new King("a", "1"));
        }
    }
}