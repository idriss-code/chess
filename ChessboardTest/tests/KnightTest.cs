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
    }
}