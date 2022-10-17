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

            Assert.IsTrue(king.AvailableMove.Count == 8);

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

            Assert.IsTrue(king.AvailableMove.Count == 3);

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

            Assert.IsTrue(king.AvailableMove.Count == 3);

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
            chessboard.AddPiece(new King("a", "2", Color.White));
            chessboard.AddPiece(new King("b", "1", Color.Black));

            Assert.IsTrue(king.AvailableMove.Count == 2);

            Assert.IsTrue(king.AvailableMove.Contains(new Square("b", "1")));
            Assert.IsTrue(king.AvailableMove.Contains(new Square("b", "2")));
        }
    }
}
