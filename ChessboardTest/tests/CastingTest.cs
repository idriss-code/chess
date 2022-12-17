using Microsoft.VisualStudio.TestTools.UnitTesting;
using chessboard.pieces;
using chessboard.enums;
using chessboard;

namespace chessboardTest
{
    [TestClass]
    public class CastingTest
    {
        [TestMethod]
        public void CastingAvailableWhite()
        {
            var king = new King("e", "1", Color.White);
            var rook1 = new Rook("a", "1", Color.White);
            var rook2 = new Rook("h", "1", Color.White);

            var chessboard = new Chessboard();
            chessboard.AddPiece(king);
            chessboard.AddPiece(rook1);
            chessboard.AddPiece(rook2);

            Assert.IsTrue(king.AvailableMove.Contains(new Square("g", "1")));
            Assert.IsTrue(king.AvailableMove.Contains(new Square("c", "1")));
        }

        [TestMethod]
        public void CastingNotAvailableWhite()
        {
            var king = new King("e", "1", Color.White);

            var chessboard = new Chessboard();
            chessboard.AddPiece(king);

            Assert.IsFalse(king.AvailableMove.Contains(new Square("g", "1")));
            Assert.IsFalse(king.AvailableMove.Contains(new Square("c", "1")));
        }

        [TestMethod]
        public void CastingAvailableBlack()
        {
            var king = new King("e", "8", Color.Black);
            var rook1 = new Rook("a", "8", Color.Black);
            var rook2 = new Rook("h", "8", Color.Black);

            var chessboard = new Chessboard();
            chessboard.AddPiece(king);
            chessboard.AddPiece(rook1);
            chessboard.AddPiece(rook2);

            Assert.IsTrue(king.AvailableMove.Contains(new Square("g", "8")));
            Assert.IsTrue(king.AvailableMove.Contains(new Square("c", "8")));
        }

        [TestMethod]
        public void CastingNotAvailableBlack()
        {
            var king = new King("e", "8", Color.Black);

            var chessboard = new Chessboard();
            chessboard.AddPiece(king);

            Assert.IsFalse(king.AvailableMove.Contains(new Square("g", "8")));
            Assert.IsFalse(king.AvailableMove.Contains(new Square("c", "8")));
        }

        [TestMethod]
        public void CastingAvailableKingSide()
        {
            var king = new King("e", "8", Color.Black);
            var rook1 = new Rook("a", "8", Color.Black);

            var chessboard = new Chessboard();
            chessboard.AddPiece(king);
            chessboard.AddPiece(rook1);

            Assert.IsFalse(king.AvailableMove.Contains(new Square("g", "8")));
            Assert.IsTrue(king.AvailableMove.Contains(new Square("c", "8")));
        }

        [TestMethod]
        public void CastingAvailableQueeSide()
        {
            var king = new King("e", "8", Color.Black);
            var rook2 = new Rook("h", "8", Color.Black);

            var chessboard = new Chessboard();
            chessboard.AddPiece(king);
            chessboard.AddPiece(rook2);

            Assert.IsTrue(king.AvailableMove.Contains(new Square("g", "8")));
            Assert.IsFalse(king.AvailableMove.Contains(new Square("c", "8")));
        }

        [TestMethod]
        public void CastingNotAvailableAfterRookMove()
        {
            var king = new King("e", "1", Color.White);
            var rook1 = new Rook("a", "1", Color.White);
            var rook2 = new Rook("h", "1", Color.White);
            var blackKing = new King("e", "8", Color.Black);

            var chessboard = new Chessboard();
            chessboard.AddPiece(king);
            chessboard.AddPiece(rook1);
            chessboard.AddPiece(rook2);
            chessboard.AddPiece(blackKing);

            Assert.IsTrue(king.AvailableMove.Contains(new Square("g", "1")));
            Assert.IsTrue(king.AvailableMove.Contains(new Square("c", "1")));

            rook1.Move("a", "2");
            blackKing.Move("e", "7");
            rook1.Move("a", "1");
            blackKing.Move("e", "8");

            Assert.IsTrue(king.AvailableMove.Contains(new Square("g", "1")));
            Assert.IsFalse(king.AvailableMove.Contains(new Square("c", "1")));

            rook2.Move("h", "2");
            blackKing.Move("e", "7");
            rook2.Move("h", "1");
            blackKing.Move("e", "8");

            Assert.IsFalse(king.AvailableMove.Contains(new Square("g", "1")));
            Assert.IsFalse(king.AvailableMove.Contains(new Square("c", "1")));
        }

        [TestMethod]
        public void CastingNotAvailableAfterKingMove()
        {
            var king = new King("e", "1", Color.White);
            var rook1 = new Rook("a", "1", Color.White);
            var rook2 = new Rook("h", "1", Color.White);
            var blackKing = new King("e", "8", Color.Black);

            var chessboard = new Chessboard();
            chessboard.AddPiece(king);
            chessboard.AddPiece(rook1);
            chessboard.AddPiece(rook2);
            chessboard.AddPiece(blackKing);

            Assert.IsTrue(king.AvailableMove.Contains(new Square("g", "1")));
            Assert.IsTrue(king.AvailableMove.Contains(new Square("c", "1")));

            king.Move("e", "2");
            blackKing.Move("e", "7");
            king.Move("e", "1");
            blackKing.Move("e", "8");

            Assert.IsFalse(king.AvailableMove.Contains(new Square("g", "1")));
            Assert.IsFalse(king.AvailableMove.Contains(new Square("c", "1")));
        }

        [TestMethod]
        public void CastingNotAvailable()
        {
            var king = new King("e", "1", Color.White);
            var rook1 = new Rook("a", "1", Color.White);
            var rook2 = new Rook("h", "1", Color.White);
            var blackKing = new King("e", "8", Color.Black);

            var chessboard = new Chessboard();
            chessboard.AddPiece(king);
            chessboard.AddPiece(rook1);
            chessboard.AddPiece(rook2);
            chessboard.AddPiece(blackKing);

            chessboard.AddPiece(new Knight("b","1"));
            chessboard.AddPiece(new Knight("g", "1"));

            Assert.IsFalse(king.AvailableMove.Contains(new Square("g", "1")));
            Assert.IsFalse(king.AvailableMove.Contains(new Square("c", "1")));
        }

        [TestMethod]
        public void RooKPositionAfterCastingKingSide()
        {
            var king = new King("e", "1", Color.White);
            var rook1 = new Rook("a", "1", Color.White);

            var chessboard = new Chessboard();
            chessboard.AddPiece(king);
            chessboard.AddPiece(rook1);

            king.Move("c", "1");

            Assert.IsTrue(rook1.Collumn == "f");
        }

        [TestMethod]
        public void RooKPositionAfterCastingQueenSide()
        {
            var king = new King("e", "1", Color.White);
            var rook2 = new Rook("h", "1", Color.White);

            var chessboard = new Chessboard();
            chessboard.AddPiece(king);
            chessboard.AddPiece(rook2);

            king.Move("g", "1");

            Assert.IsTrue(rook2.Collumn == "d");
        }
    }
}