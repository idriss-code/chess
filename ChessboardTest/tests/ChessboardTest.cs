using Microsoft.VisualStudio.TestTools.UnitTesting;
using chessboard;
using chessboard.pieces;

namespace chessboardTest
{
    [TestClass]
    public class ChessboardTest
    {
        [TestMethod]
        public void ChessboardCreation()
        {
            var chessboard = new Chessboard();
            Assert.IsNotNull(chessboard);
        }

        [TestMethod]
        public void GameCreation()
        {
            var chessboard = new Chessboard();
            chessboard.NewGame();
            var king = chessboard.GetSquare("e", "1");
            Assert.IsTrue(king is King);
        }
    }
}