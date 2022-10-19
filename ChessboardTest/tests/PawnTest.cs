using Microsoft.VisualStudio.TestTools.UnitTesting;
using chessboard.pieces;
using chessboard.enums;
using chessboard;

namespace chessboardTest
{
    [TestClass]
    public class PawnTest
    {
        [TestMethod]
        public void PawnCreation()
        {
            var pawn = new Pawn();
            Assert.IsNotNull(pawn);
            Assert.AreEqual(pawn.Name, "Pawn");
        }

        [TestMethod]
        public void PawnMove1()
        {
            var chessboard = new Chessboard();

            var pawn = new Pawn("d", "5",Color.White);
            chessboard.AddPiece(pawn);

            Assert.IsTrue(pawn.AvailableMove.Count == 1);
            Assert.IsTrue(pawn.AvailableMove.Contains(new Square("d", "6")));
        }

        [TestMethod]
        public void PawnMove2()
        {
            var chessboard = new Chessboard();

            var pawn = new Pawn("d", "5",Color.Black);
            chessboard.AddPiece(pawn);

            Assert.IsTrue(pawn.AvailableMove.Count == 1);
            Assert.IsTrue(pawn.AvailableMove.Contains(new Square("d", "4")));
        }
    }
}
