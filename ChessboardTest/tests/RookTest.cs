using Microsoft.VisualStudio.TestTools.UnitTesting;
using chessboard.pieces;
using chessboard.enums;
using chessboard;

namespace chessboardTest
{
    [TestClass]
    public class RookTest
    {
        [TestMethod]
        public void RookCreation()
        {
            var rook = new Rook();
            Assert.IsNotNull(rook);
            Assert.AreEqual(rook.Name, "Rook");
        }


        [TestMethod]
        public void RookMove1()
        {
            var chessboard = new Chessboard();

            var rook = new Rook("d","5");
            chessboard.AddPiece(rook);

            Assert.IsTrue(rook.AvailableMove.Count == 14);

            Assert.IsTrue(rook.AvailableMove.Contains(new Square("d", "1")));
            Assert.IsTrue(rook.AvailableMove.Contains(new Square("d", "8")));
            Assert.IsTrue(rook.AvailableMove.Contains(new Square("a", "5")));
            Assert.IsTrue(rook.AvailableMove.Contains(new Square("h", "5")));

            Assert.IsTrue(rook.AvailableMove.Contains(new Square("d", "4")));
            Assert.IsTrue(rook.AvailableMove.Contains(new Square("d", "6")));
            Assert.IsTrue(rook.AvailableMove.Contains(new Square("c", "5")));
            Assert.IsTrue(rook.AvailableMove.Contains(new Square("e", "5")));

        }
    }
}
