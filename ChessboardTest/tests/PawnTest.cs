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

        [TestMethod]
        public void PawnMove3()
        {
            var chessboard = new Chessboard();

            var blackpawn = new Pawn("d", "5", Color.Black);
            chessboard.AddPiece(blackpawn);
            var whitepawn = new Pawn("d", "4", Color.White);
            chessboard.AddPiece(whitepawn);

            Assert.IsTrue(blackpawn.AvailableMove.Count == 0);
            Assert.IsTrue(whitepawn.AvailableMove.Count == 0);
        }

        [TestMethod]
        public void PawnMove4()
        {
            var chessboard = new Chessboard();

            var pawn = new Pawn("d", "2", Color.White);
            chessboard.AddPiece(pawn);

            Assert.IsTrue(pawn.AvailableMove.Count == 2);
            Assert.IsTrue(pawn.AvailableMove.Contains(new Square("d", "3")));
            Assert.IsTrue(pawn.AvailableMove.Contains(new Square("d", "4")));
        }

        [TestMethod]
        public void PawnMove5()
        {
            var chessboard = new Chessboard();

            var pawn = new Pawn("d", "7", Color.Black);
            chessboard.AddPiece(pawn);

            Assert.IsTrue(pawn.AvailableMove.Count == 2);
            Assert.IsTrue(pawn.AvailableMove.Contains(new Square("d", "6")));
            Assert.IsTrue(pawn.AvailableMove.Contains(new Square("d", "5")));
        }

        [TestMethod]
        public void PawnMove6()
        {
            var chessboard = new Chessboard();

            var pawn = new Pawn("d", "2", Color.White);
            chessboard.AddPiece(pawn);
            chessboard.AddPiece(new Pawn("c", "3", Color.Black));
            chessboard.AddPiece(new Pawn("e", "3", Color.Black));

            Assert.IsTrue(pawn.AvailableMove.Count == 4);
            Assert.IsTrue(pawn.AvailableMove.Contains(new Square("c", "3")));
            Assert.IsTrue(pawn.AvailableMove.Contains(new Square("e", "3")));
        }

        [TestMethod]
        public void PawnMove7()
        {
            var chessboard = new Chessboard();

            var pawn = new Pawn("d", "7", Color.Black);
            chessboard.AddPiece(pawn);
            chessboard.AddPiece(new Pawn("c", "6", Color.White));
            chessboard.AddPiece(new Pawn("e", "6", Color.White));

            Assert.IsTrue(pawn.AvailableMove.Count == 4);
            Assert.IsTrue(pawn.AvailableMove.Contains(new Square("c", "6")));
            Assert.IsTrue(pawn.AvailableMove.Contains(new Square("e", "6")));
        }
    }
}
