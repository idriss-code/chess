using Microsoft.VisualStudio.TestTools.UnitTesting;
using chessboard.pieces;

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
            Assert.AreEqual(king.name, "King");
        }
    }
}
