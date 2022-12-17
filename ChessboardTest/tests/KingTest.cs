using Microsoft.VisualStudio.TestTools.UnitTesting;
using chessboard.pieces;
using chessboard.enums;
using chessboard;

namespace chessboardTest
{
    [TestClass]
    public class KingTest
    {
        [TestMethod]
        public void KingCreation()
        {
            var king = new King();
            Assert.IsNotNull(king);
            Assert.AreEqual(king.Name, "King");
        }

        [TestMethod]
        public void KingMove1()
        {
            var chessboard = new Chessboard();

            var king = new King("d", "4");
            chessboard.AddPiece(king);

            Assert.AreEqual(8, king.AvailableMove.Count);

            Assert.IsTrue(king.AvailableMove.Contains(new Square("c", "5")));
            Assert.IsTrue(king.AvailableMove.Contains(new Square("d", "5")));
            Assert.IsTrue(king.AvailableMove.Contains(new Square("e", "5")));

            Assert.IsTrue(king.AvailableMove.Contains(new Square("c","4")));
            Assert.IsTrue(king.AvailableMove.Contains(new Square("e","4")));

            Assert.IsTrue(king.AvailableMove.Contains(new Square("c", "3")));
            Assert.IsTrue(king.AvailableMove.Contains(new Square("d", "3")));
            Assert.IsTrue(king.AvailableMove.Contains(new Square("e", "3")));

            Assert.IsFalse(king.AvailableMove.Contains(new Square("d", "4")));
        }

        [TestMethod]
        public void KingMove2()
        {
            var chessboard = new Chessboard();

            var king = new King("a", "8");
            chessboard.AddPiece(king);

            Assert.AreEqual(3, king.AvailableMove.Count);

            Assert.IsTrue(king.AvailableMove.Contains(new Square("b", "8")));
            Assert.IsTrue(king.AvailableMove.Contains(new Square("b", "7")));
            Assert.IsTrue(king.AvailableMove.Contains(new Square("a", "7")));
        }

        [TestMethod]
        public void KingMove3()
        {
            var chessboard = new Chessboard();

            var king = new King("h", "1");
            chessboard.AddPiece(king);

            Assert.AreEqual(3, king.AvailableMove.Count);

            Assert.IsTrue(king.AvailableMove.Contains(new Square("g", "1")));
            Assert.IsTrue(king.AvailableMove.Contains(new Square("g", "2")));
            Assert.IsTrue(king.AvailableMove.Contains(new Square("h", "2")));
        }

        [TestMethod]
        public void KingMove4()
        {
            var chessboard = new Chessboard();

            var king = new King("a", "1", Color.White);
            chessboard.AddPiece(king);
            chessboard.AddPiece(new Pawn("a", "2", Color.White));
            chessboard.AddPiece(new Bishop("b", "1", Color.Black));

            Assert.AreEqual(2, king.AvailableMove.Count);

            Assert.IsTrue(king.AvailableMove.Contains(new Square("b", "1")));
            Assert.IsTrue(king.AvailableMove.Contains(new Square("b", "2")));
        }

        [TestMethod]
        public void KingMove5()
        {
            var chessboard = new Chessboard();

            var king = new King("d", "4", Color.White);
            chessboard.AddPiece(king);
            chessboard.AddPiece(new Rook("a", "5", Color.Black));
            chessboard.AddPiece(new Rook("a", "3", Color.Black));

            Assert.AreEqual(2, king.AvailableMove.Count);

            Assert.IsTrue(king.AvailableMove.Contains(new Square("c", "4")));
            Assert.IsTrue(king.AvailableMove.Contains(new Square("e", "4")));
        }
    }
}
