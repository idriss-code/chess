using Microsoft.VisualStudio.TestTools.UnitTesting;
using chessboard.pieces;
using chessboard.enums;
using chessboard;

namespace chessboardTest
{
    [TestClass]
    public class QueenTest
    {
        [TestMethod]
        public void QueenCreation()
        {
            var queen = new Queen();
            Assert.IsNotNull(queen);
            Assert.AreEqual(queen.Name, "Queen");
        }

        [TestMethod]
        public void QueenMove1()
        {
            var chessboard = new Chessboard();

            var queen = new Queen("d", "5");
            chessboard.AddPiece(queen);

            Assert.IsTrue(queen.AvailableMove.Count == 14 + 13);

            Assert.IsTrue(queen.AvailableMove.Contains(new Square("d", "1")));
            Assert.IsTrue(queen.AvailableMove.Contains(new Square("d", "8")));
            Assert.IsTrue(queen.AvailableMove.Contains(new Square("a", "5")));
            Assert.IsTrue(queen.AvailableMove.Contains(new Square("h", "5")));

            Assert.IsTrue(queen.AvailableMove.Contains(new Square("d", "4")));
            Assert.IsTrue(queen.AvailableMove.Contains(new Square("d", "6")));
            Assert.IsTrue(queen.AvailableMove.Contains(new Square("c", "5")));
            Assert.IsTrue(queen.AvailableMove.Contains(new Square("e", "5")));

            Assert.IsTrue(queen.AvailableMove.Contains(new Square("a", "8")));
            Assert.IsTrue(queen.AvailableMove.Contains(new Square("g", "8")));
            Assert.IsTrue(queen.AvailableMove.Contains(new Square("a", "2")));
            Assert.IsTrue(queen.AvailableMove.Contains(new Square("h", "1")));
        }

        [TestMethod]
        public void QueenMove2()
        {
            var chessboard = new Chessboard();

            var queen = new Queen("d", "5", Color.White);
            chessboard.AddPiece(queen);
            chessboard.AddPiece(new King("d", "7", Color.Black));
            chessboard.AddPiece(new King("d", "2", Color.Black));
            chessboard.AddPiece(new King("b", "5", Color.Black));
            chessboard.AddPiece(new King("g", "5", Color.Black));

            Assert.IsTrue(queen.AvailableMove.Contains(new Square("d", "7")));
            Assert.IsTrue(queen.AvailableMove.Contains(new Square("d", "2")));
            Assert.IsTrue(queen.AvailableMove.Contains(new Square("b", "5")));
            Assert.IsTrue(queen.AvailableMove.Contains(new Square("g", "5")));

            Assert.IsFalse(queen.AvailableMove.Contains(new Square("d", "8")));
            Assert.IsFalse(queen.AvailableMove.Contains(new Square("d", "1")));
            Assert.IsFalse(queen.AvailableMove.Contains(new Square("a", "5")));
            Assert.IsFalse(queen.AvailableMove.Contains(new Square("h", "5")));
        }

        [TestMethod]
        public void QueenMove3()
        {
            var chessboard = new Chessboard();

            var queen = new Queen("d", "5", Color.White);
            chessboard.AddPiece(queen);
            chessboard.AddPiece(new King("d", "7", Color.White));
            chessboard.AddPiece(new King("d", "2", Color.White));
            chessboard.AddPiece(new King("b", "5", Color.White));
            chessboard.AddPiece(new King("g", "5", Color.White));

            Assert.IsTrue(queen.AvailableMove.Contains(new Square("d", "6")));
            Assert.IsTrue(queen.AvailableMove.Contains(new Square("d", "3")));
            Assert.IsTrue(queen.AvailableMove.Contains(new Square("c", "5")));
            Assert.IsTrue(queen.AvailableMove.Contains(new Square("f", "5")));

            Assert.IsFalse(queen.AvailableMove.Contains(new Square("d", "7")));
            Assert.IsFalse(queen.AvailableMove.Contains(new Square("d", "2")));
            Assert.IsFalse(queen.AvailableMove.Contains(new Square("b", "5")));
            Assert.IsFalse(queen.AvailableMove.Contains(new Square("g", "5")));

            Assert.IsFalse(queen.AvailableMove.Contains(new Square("d", "8")));
            Assert.IsFalse(queen.AvailableMove.Contains(new Square("d", "1")));
            Assert.IsFalse(queen.AvailableMove.Contains(new Square("a", "5")));
            Assert.IsFalse(queen.AvailableMove.Contains(new Square("h", "5")));
        }

        [TestMethod]
        public void QueenMove4()
        {
            var chessboard = new Chessboard();

            var queen = new Queen("d", "5", Color.White);
            chessboard.AddPiece(queen);
            chessboard.AddPiece(new King("f", "7", Color.Black));
            chessboard.AddPiece(new King("b", "7", Color.Black));
            chessboard.AddPiece(new King("b", "3", Color.Black));
            chessboard.AddPiece(new King("f", "3", Color.Black));

            Assert.IsTrue(queen.AvailableMove.Count == 14 + 8);

            Assert.IsTrue(queen.AvailableMove.Contains(new Square("c", "6")));
            Assert.IsTrue(queen.AvailableMove.Contains(new Square("c", "4")));
            Assert.IsTrue(queen.AvailableMove.Contains(new Square("e", "6")));
            Assert.IsTrue(queen.AvailableMove.Contains(new Square("e", "4")));

            Assert.IsTrue(queen.AvailableMove.Contains(new Square("f", "7")));
            Assert.IsTrue(queen.AvailableMove.Contains(new Square("b", "7")));
            Assert.IsTrue(queen.AvailableMove.Contains(new Square("b", "3")));
            Assert.IsTrue(queen.AvailableMove.Contains(new Square("f", "3")));
        }

        [TestMethod]
        public void QueenMove5()
        {
            var chessboard = new Chessboard();

            var queen = new Queen("d", "5", Color.White);
            chessboard.AddPiece(queen);
            chessboard.AddPiece(new King("f", "7", Color.White));
            chessboard.AddPiece(new King("b", "7", Color.White));
            chessboard.AddPiece(new King("b", "3", Color.White));
            chessboard.AddPiece(new King("f", "3", Color.White));

            Assert.IsTrue(queen.AvailableMove.Count == 14 + 4);

            Assert.IsTrue(queen.AvailableMove.Contains(new Square("c", "6")));
            Assert.IsTrue(queen.AvailableMove.Contains(new Square("c", "4")));
            Assert.IsTrue(queen.AvailableMove.Contains(new Square("e", "6")));
            Assert.IsTrue(queen.AvailableMove.Contains(new Square("e", "4")));

            Assert.IsFalse(queen.AvailableMove.Contains(new Square("f", "7")));
            Assert.IsFalse(queen.AvailableMove.Contains(new Square("b", "7")));
            Assert.IsFalse(queen.AvailableMove.Contains(new Square("b", "3")));
            Assert.IsFalse(queen.AvailableMove.Contains(new Square("f", "3")));
        }
    }
}
