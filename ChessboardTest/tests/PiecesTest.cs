using Microsoft.VisualStudio.TestTools.UnitTesting;
using chessboard.pieces;
using chessboard;

namespace chessboardTest
{
    [TestClass]
    public class PiecesTest
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
    }
}
