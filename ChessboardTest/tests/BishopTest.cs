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
        public void BishopCreation()
        {
            var bishop = new Bishop();
            Assert.IsNotNull(bishop);
            Assert.AreEqual(bishop.Name, "Bishop");
        }

        [TestMethod]
        public void BishopMove1()
        {
            var chessboard = new Chessboard();

            var bishop = new Bishop("d", "5");
            chessboard.AddPiece(bishop);

            Assert.IsTrue(bishop.AvailableMove.Count == 13);

            Assert.IsTrue(bishop.AvailableMove.Contains(new Square("a", "8")));
            Assert.IsTrue(bishop.AvailableMove.Contains(new Square("g", "8")));
            Assert.IsTrue(bishop.AvailableMove.Contains(new Square("a", "2")));
            Assert.IsTrue(bishop.AvailableMove.Contains(new Square("h", "1")));
        }

        [TestMethod]
        public void BishopMove2()
        {
            var chessboard = new Chessboard();

            var bishop = new Bishop("d", "5", Color.White);
            chessboard.AddPiece(bishop);
            chessboard.AddPiece(new King("f", "7", Color.Black));
            chessboard.AddPiece(new King("b", "7", Color.Black));
            chessboard.AddPiece(new King("b", "3", Color.Black));
            chessboard.AddPiece(new King("f", "3", Color.Black));

            Assert.IsTrue(bishop.AvailableMove.Count == 8);

            Assert.IsTrue(bishop.AvailableMove.Contains(new Square("c", "6")));
            Assert.IsTrue(bishop.AvailableMove.Contains(new Square("c", "4")));
            Assert.IsTrue(bishop.AvailableMove.Contains(new Square("e", "6")));
            Assert.IsTrue(bishop.AvailableMove.Contains(new Square("e", "4")));

            Assert.IsTrue(bishop.AvailableMove.Contains(new Square("f", "7")));
            Assert.IsTrue(bishop.AvailableMove.Contains(new Square("b", "7")));
            Assert.IsTrue(bishop.AvailableMove.Contains(new Square("b", "3")));
            Assert.IsTrue(bishop.AvailableMove.Contains(new Square("f", "3")));
        }

        [TestMethod]
        public void BishopMove3()
        {
            var chessboard = new Chessboard();

            var bishop = new Bishop("d", "5", Color.White);
            chessboard.AddPiece(bishop);
            chessboard.AddPiece(new King("f", "7", Color.White));
            chessboard.AddPiece(new King("b", "7", Color.White));
            chessboard.AddPiece(new King("b", "3", Color.White));
            chessboard.AddPiece(new King("f", "3", Color.White));

            Assert.IsTrue(bishop.AvailableMove.Count == 4);

            Assert.IsTrue(bishop.AvailableMove.Contains(new Square("c", "6")));
            Assert.IsTrue(bishop.AvailableMove.Contains(new Square("c", "4")));
            Assert.IsTrue(bishop.AvailableMove.Contains(new Square("e", "6")));
            Assert.IsTrue(bishop.AvailableMove.Contains(new Square("e", "4")));

            Assert.IsFalse(bishop.AvailableMove.Contains(new Square("f", "7")));
            Assert.IsFalse(bishop.AvailableMove.Contains(new Square("b", "7")));
            Assert.IsFalse(bishop.AvailableMove.Contains(new Square("b", "3")));
            Assert.IsFalse(bishop.AvailableMove.Contains(new Square("f", "3")));
        }
    }
}
