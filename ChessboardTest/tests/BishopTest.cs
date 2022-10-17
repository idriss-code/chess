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
        public void RookCreation()
        {
            var bishop = new Bishop();
            Assert.IsNotNull(bishop);
            Assert.AreEqual(bishop.Name, "Bishop");
        }
    }
}
