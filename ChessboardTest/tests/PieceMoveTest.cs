using Microsoft.VisualStudio.TestTools.UnitTesting;
using chessboard.pieces;
using chessboard.enums;
using chessboard;
using System.Linq;
using chessboard.exceptions;

namespace chessboardTest
{
    [TestClass]
    public class PieceMoveTest
    {
        [TestMethod]
        public void PieceMove1()
        {
            var chessboard = new Chessboard();

            chessboard.AddPiece(new King("d", "5"));
            IPiece? piece = chessboard.GetSquare("d", "5");
            Assert.IsNotNull(piece);

            piece.Move("d", "6");
            piece = null;
            piece = chessboard.GetSquare("d", "6");
            Assert.IsNotNull(piece);
        }

        [TestMethod]
        public void PieceMove2()
        {

            IPiece[] tab = { new King("d", "5"), new Queen("d", "5"), new Rook("d", "5"), new Bishop("d", "5"), new Pawn("d", "5") };

            foreach (IPiece currentPiece in tab)
            {
                var chessboard = new Chessboard();

                chessboard.AddPiece(currentPiece);
                IPiece? piece = chessboard.GetSquare("d", "5");
                Assert.IsNotNull(piece);

                Square s = currentPiece.AvailableMove.First<Square>();

                piece.Move(s.Collumn, s.Row);
                piece = null;
                piece = chessboard.GetSquare(s.Collumn, s.Row);
                Assert.IsNotNull(piece);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ChessBoardException), "Invalid move")]
        public void PieceMove3()
        {
            var chessboard = new Chessboard();
            var king = new King("d", "5");
            chessboard.AddPiece(king);
            king.Move("d", "7");
        }

        [TestMethod]
        public void PieceMove4()
        {
            var chessboard = new Chessboard();
            var king = new King("d", "5",Color.White);
            chessboard.AddPiece(king);
            var pawn = new Pawn("e", "5",Color.Black);
            chessboard.AddPiece(pawn);

            king.Move("e", "5");

            Assert.IsTrue(chessboard.GetSquare("e", "5") == king);

            Assert.IsTrue(chessboard.RemovedPieces.Contains(pawn));
        }

        [TestMethod]
        [ExpectedException(typeof(ChessBoardException), "Invalid move")]
        public void PieceMove5()
        {
            var chessboard = new Chessboard();
            var king = new King("d", "5", Color.White);
            chessboard.AddPiece(king);
            var pawn = new Pawn("e", "5", Color.White);
            chessboard.AddPiece(pawn);

            king.Move("e", "5");
        }
    }
}
