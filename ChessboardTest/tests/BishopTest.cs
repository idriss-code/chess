using Microsoft.VisualStudio.TestTools.UnitTesting;
using chessboard.pieces;
using chessboard.enums;
using chessboard;

namespace chessboardTest
{
    [TestClass]
    public class BishopTest
    {
        [TestMethod]
        public void BishopCreation()
        {
            var bishop = new Bishop();
            Assert.IsNotNull(bishop);
            Assert.AreEqual(bishop.Name, "Bishop");
        }

        [TestMethod]
        public void BishopMove1()
        {
            var chessboard = new Chessboard();

            var bishop = new Bishop("d", "5");
            chessboard.AddPiece(bishop);

            Assert.IsTrue(bishop.AvailableMove.Count == 13);

            Assert.IsTrue(bishop.AvailableMove.Contains(new Square("a", "8")));
            Assert.IsTrue(bishop.AvailableMove.Contains(new Square("g", "8")));

            Assert.IsTrue(bishop.AvailableMove.Contains(new Square("a", "2")));
            Assert.IsTrue(bishop.AvailableMove.Contains(new Square("h", "1")));
        }
    }
}
