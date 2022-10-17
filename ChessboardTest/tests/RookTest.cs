using Microsoft.VisualStudio.TestTools.UnitTesting;
using chessboard.pieces;
using chessboard.enums;
using chessboard;

namespace chessboardTest
{
    [TestClass]
    public class RookTest
    {
        [TestMethod]
        public void RookCreation()
        {
            var rook = new Rook();
            Assert.IsNotNull(rook);
            Assert.AreEqual(rook.Name, "Rook");
        }


        [TestMethod]
        public void RookMove1()
        {
            var chessboard = new Chessboard();

            var rook = new Rook("d","5");
            chessboard.AddPiece(rook);

            Assert.IsTrue(rook.AvailableMove.Count == 14);

            Assert.IsTrue(rook.AvailableMove.Contains(new Square("d", "1")));
            Assert.IsTrue(rook.AvailableMove.Contains(new Square("d", "8")));
            Assert.IsTrue(rook.AvailableMove.Contains(new Square("a", "5")));
            Assert.IsTrue(rook.AvailableMove.Contains(new Square("h", "5")));

            Assert.IsTrue(rook.AvailableMove.Contains(new Square("d", "4")));
            Assert.IsTrue(rook.AvailableMove.Contains(new Square("d", "6")));
            Assert.IsTrue(rook.AvailableMove.Contains(new Square("c", "5")));
            Assert.IsTrue(rook.AvailableMove.Contains(new Square("e", "5")));

        }

        [TestMethod]
        public void RookMove2()
        {
            var chessboard = new Chessboard();

            var rook = new Rook("d", "5", Color.White);
            chessboard.AddPiece(rook);
            chessboard.AddPiece(new King("d", "7", Color.Black));
            chessboard.AddPiece(new King("d", "2", Color.Black));
            chessboard.AddPiece(new King("b", "5", Color.Black));
            chessboard.AddPiece(new King("g", "5", Color.Black));

            Assert.IsTrue(rook.AvailableMove.Contains(new Square("d", "7")));
            Assert.IsTrue(rook.AvailableMove.Contains(new Square("d", "2")));
            Assert.IsTrue(rook.AvailableMove.Contains(new Square("b", "5")));
            Assert.IsTrue(rook.AvailableMove.Contains(new Square("g", "5")));

            Assert.IsFalse(rook.AvailableMove.Contains(new Square("d", "8")));
            Assert.IsFalse(rook.AvailableMove.Contains(new Square("d", "1")));
            Assert.IsFalse(rook.AvailableMove.Contains(new Square("a", "5")));
            Assert.IsFalse(rook.AvailableMove.Contains(new Square("h", "5")));
        }

        [TestMethod]
        public void RookMove3()
        {
            var chessboard = new Chessboard();

            var rook = new Rook("d", "5", Color.White);
            chessboard.AddPiece(rook);
            chessboard.AddPiece(new King("d", "7", Color.White));
            chessboard.AddPiece(new King("d", "2", Color.White));
            chessboard.AddPiece(new King("b", "5", Color.White));
            chessboard.AddPiece(new King("g", "5", Color.White));

            Assert.IsTrue(rook.AvailableMove.Contains(new Square("d", "6")));
            Assert.IsTrue(rook.AvailableMove.Contains(new Square("d", "3")));
            Assert.IsTrue(rook.AvailableMove.Contains(new Square("c", "5")));
            Assert.IsTrue(rook.AvailableMove.Contains(new Square("f", "5")));

            Assert.IsFalse(rook.AvailableMove.Contains(new Square("d", "7")));
            Assert.IsFalse(rook.AvailableMove.Contains(new Square("d", "2")));
            Assert.IsFalse(rook.AvailableMove.Contains(new Square("b", "5")));
            Assert.IsFalse(rook.AvailableMove.Contains(new Square("g", "5")));

            Assert.IsFalse(rook.AvailableMove.Contains(new Square("d", "8")));
            Assert.IsFalse(rook.AvailableMove.Contains(new Square("d", "1")));
            Assert.IsFalse(rook.AvailableMove.Contains(new Square("a", "5")));
            Assert.IsFalse(rook.AvailableMove.Contains(new Square("h", "5")));
        }
    }
}
