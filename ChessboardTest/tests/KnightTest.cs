using Microsoft.VisualStudio.TestTools.UnitTesting;
using chessboard.pieces;
using chessboard.enums;
using chessboard;

namespace chessboardTest
{
    [TestClass]
    public class KnightTest
    {
        [TestMethod]
        public void KnightCreation()
        {
            var knight = new Knight();
            Assert.IsNotNull(knight);
            Assert.AreEqual(knight.Name, "Knight");
        }

        [TestMethod]
        public void KnightMove()
        {
            var chessboard = new Chessboard();

            var knight = new Knight("d","5");
            chessboard.AddPiece(knight);

            Assert.IsTrue(knight.AvailableMove.Count == 8);
            Assert.IsTrue(knight.AvailableMove.Contains(new Square("c", "7")));
            Assert.IsTrue(knight.AvailableMove.Contains(new Square("e", "7")));

            Assert.IsTrue(knight.AvailableMove.Contains(new Square("c", "3")));
            Assert.IsTrue(knight.AvailableMove.Contains(new Square("e", "3")));

            Assert.IsTrue(knight.AvailableMove.Contains(new Square("b", "6")));
            Assert.IsTrue(knight.AvailableMove.Contains(new Square("b", "4")));

            Assert.IsTrue(knight.AvailableMove.Contains(new Square("f", "6")));
            Assert.IsTrue(knight.AvailableMove.Contains(new Square("f", "4")));
        }
    }
}