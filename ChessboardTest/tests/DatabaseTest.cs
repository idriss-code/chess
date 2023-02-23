using chessboard.pieces;
using chessboard;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using chessboard.enums;

namespace chessboardTest.tests
{
    [TestClass]
    public class DatabaseTest
    {
        [TestMethod]
        public void SaveAndLoad()
        {
            var chessboardToSave = new Chessboard();
            var king = new King("d", "4");
            chessboardToSave.AddPiece(king);
            int id = chessboardToSave.Save();

            var chessboardToLoad = new Chessboard();
            chessboardToLoad.Load(id);
            var piece = chessboardToLoad.GetPieceOnSquare("d", "4");
            Assert.IsTrue(piece is King);
            Assert.IsTrue(piece?.Color == Color.White);
            Assert.Equals(chessboardToLoad.Pieces.Count, 1);
        }
    }
}
