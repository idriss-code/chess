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
            var king = chessboard.GetSquare("e", "1");
            Assert.IsTrue(king is King);
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