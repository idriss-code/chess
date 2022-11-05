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
        public void EnPassantAivalableMove()
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
        public void EnPassantKill()
        {
            var chessboard = new Chessboard();
            var blackPawn = new Pawn("g", "7", Color.Black);
            var whitePawn = new Pawn("f", "5", Color.White);

            chessboard.AddPiece(blackPawn);
            chessboard.AddPiece(whitePawn);

            blackPawn.Move("g", "5");
            whitePawn.Move("g", "6");

            Assert.IsTrue(chessboard.GetSquare("g", "5") == null);
            Assert.IsTrue(chessboard.RemovedPieces.Contains(blackPawn));
        }

        [TestMethod]
        public void EnPassantLeftEdge()
        {
            var chessboard = new Chessboard();
            var blackPawn = new Pawn("a", "7", Color.Black);
            var whitePawn = new Pawn("b", "5", Color.White);

            chessboard.AddPiece(blackPawn);
            chessboard.AddPiece(whitePawn);

            blackPawn.Move("a", "5");
            Assert.IsTrue(whitePawn.AvailableMove.Contains(new Square("a", "6")));
        }

        [TestMethod]
        public void EnPassantRightEdge()
        {
            var chessboard = new Chessboard();
            var blackPawn = new Pawn("h", "7", Color.Black);
            var whitePawn = new Pawn("g", "5", Color.White);

            chessboard.AddPiece(blackPawn);
            chessboard.AddPiece(whitePawn);

            blackPawn.Move("h", "5");
            Assert.IsTrue(whitePawn.AvailableMove.Contains(new Square("h", "6")));
        }

        [TestMethod]
        public void EnPassantKillWhite()
        {
            var chessboard = new Chessboard();
            var blackPawn = new Pawn("e", "4", Color.Black);
            var whitePawn = new Pawn("d", "2", Color.White);

            chessboard.AddPiece(blackPawn);
            chessboard.AddPiece(whitePawn);
            
            whitePawn.Move("d", "4");
            blackPawn.Move("d", "3");

            Assert.IsTrue(chessboard.GetSquare("d", "4") == null);
            Assert.IsTrue(chessboard.RemovedPieces.Contains(whitePawn));
        }

        [TestMethod]
        public void EnPassantResetAivalableMove()
        {
            var chessboard = new Chessboard();
            var blackPawn = new Pawn("g", "7", Color.Black);
            var whitePawn1 = new Pawn("f", "5", Color.White);
            var whitePawn2 = new Pawn("a", "2", Color.White);

            chessboard.AddPiece(blackPawn);
            chessboard.AddPiece(whitePawn1);
            chessboard.AddPiece(whitePawn2);

            blackPawn.Move("g", "5");
            Assert.IsTrue(whitePawn1.AvailableMove.Contains(new Square("g", "6")));

            whitePawn2.Move("a", "3");
            Assert.IsFalse(whitePawn1.AvailableMove.Contains(new Square("g", "6")));
        }
    }
}