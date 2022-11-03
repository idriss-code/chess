using Microsoft.VisualStudio.TestTools.UnitTesting;
using chessboard.pieces;
using chessboard.enums;
using chessboard;

namespace chessboardTest
{
    [TestClass]
    public class EnPassantTest
    {
        [TestMethod]
        public void EnPassant1()
        {
            var chessboard = new Chessboard();
            var blackPawn = new Pawn("g","7",Color.Black);
            var whitePawn = new Pawn("f","5", Color.White);

            chessboard.AddPiece(blackPawn);
            chessboard.AddPiece(whitePawn);

            blackPawn.Move("g", "5");
            Assert.IsTrue(whitePawn.AvailableMove.Contains(new Square("g", "6")));
        }

        [TestMethod]
        public void EnPassant2()
        {
            var chessboard = new Chessboard();
            var blackPawn = new Pawn("g", "7", Color.Black);
            var whitePawn = new Pawn("f", "5", Color.White);

            chessboard.AddPiece(blackPawn);
            chessboard.AddPiece(whitePawn);

            blackPawn.Move("g", "5");
            whitePawn.Move("g", "6");

            Assert.IsTrue(chessboard.GetSquare("g", "5") == null);
        }
    }
}