using Microsoft.VisualStudio.TestTools.UnitTesting;
using chessboard;
using chessboard.pieces;
using chessboard.enums;
using chessboard.exceptions;
using System.Collections.Generic;
using System;

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

            var whiteRook1 = chessboard.GetSquare("a", "1");
            Assert.IsTrue(whiteRook1 is Rook);
            Assert.IsTrue(whiteRook1?.Color == Color.White);
            var whiteKnight1 = chessboard.GetSquare("b", "1");
            Assert.IsTrue(whiteKnight1 is Knight);
            Assert.IsTrue(whiteKnight1?.Color == Color.White);
            var whiteBishop1 = chessboard.GetSquare("c", "1");
            Assert.IsTrue(whiteBishop1 is Bishop);
            Assert.IsTrue(whiteBishop1?.Color == Color.White);
            var whiteQueen = chessboard.GetSquare("d", "1");
            Assert.IsTrue(whiteQueen is Queen);
            Assert.IsTrue(whiteQueen?.Color == Color.White);
            var whiteKing = chessboard.GetSquare("e", "1");
            Assert.IsTrue(whiteKing is King);
            Assert.IsTrue(whiteKing?.Color == Color.White);
            var whiteBishop2 = chessboard.GetSquare("f", "1");
            Assert.IsTrue(whiteBishop2 is Bishop);
            Assert.IsTrue(whiteBishop2?.Color == Color.White);
            var whiteKnight2 = chessboard.GetSquare("g", "1");
            Assert.IsTrue(whiteKnight2 is Knight);
            Assert.IsTrue(whiteKnight2?.Color == Color.White);
            var whiteRook2 = chessboard.GetSquare("h", "1");
            Assert.IsTrue(whiteRook2 is Rook);
            Assert.IsTrue(whiteRook2?.Color == Color.White);

            var blackRook1 = chessboard.GetSquare("a", "8");
            Assert.IsTrue(blackRook1 is Rook);
            Assert.IsTrue(blackRook1?.Color == Color.Black);
            var blackKnight1 = chessboard.GetSquare("b", "8");
            Assert.IsTrue(blackKnight1 is Knight);
            Assert.IsTrue(blackKnight1?.Color == Color.Black);
            var blackBishop1 = chessboard.GetSquare("c", "8");
            Assert.IsTrue(blackBishop1 is Bishop);
            Assert.IsTrue(blackBishop1?.Color == Color.Black);
            var blackQueen = chessboard.GetSquare("d", "8");
            Assert.IsTrue(blackQueen is Queen);
            Assert.IsTrue(blackQueen?.Color == Color.Black);
            var blackKing = chessboard.GetSquare("e", "8");
            Assert.IsTrue(blackKing is King);
            Assert.IsTrue(blackKing?.Color == Color.Black);
            var blackBishop2 = chessboard.GetSquare("f", "8");
            Assert.IsTrue(blackBishop2 is Bishop);
            Assert.IsTrue(blackBishop2?.Color == Color.Black);
            var blackKnight2 = chessboard.GetSquare("g", "8");
            Assert.IsTrue(blackKnight2 is Knight);
            Assert.IsTrue(blackKnight2?.Color == Color.Black);
            var blackRook2 = chessboard.GetSquare("h", "8");
            Assert.IsTrue(blackRook2 is Rook);
            Assert.IsTrue(blackRook2?.Color == Color.Black);

            var cols = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h" };
            foreach (string col in cols)
            {
                var blackPawn = chessboard.GetSquare(col, "7");
                Assert.IsTrue(blackPawn is Pawn);
                Assert.IsTrue(blackPawn?.Color == Color.Black);

                var whitePawn = chessboard.GetSquare(col, "2");
                Assert.IsTrue(whitePawn is Pawn);
                Assert.IsTrue(whitePawn?.Color == Color.White);
            }
        }

        [TestMethod]
        public void AddPiece()
        {
            var chessboard = new Chessboard();
            chessboard.AddPiece(new King("a", "1"));
            var king = chessboard.GetSquare("a", "1");
            Assert.IsTrue(king is King);
        }

        [TestMethod]
        [ExpectedException(typeof(ChessBoardException), "Invalid square")]
        public void AddPieceOutside()
        {
            var chessboard = new Chessboard();
            chessboard.AddPiece(new King("", ""));
        }

        [TestMethod]
        [ExpectedException(typeof(ChessBoardException), "Invalid square")]
        public void AddPieceOutsideRow()
        {
            var chessboard = new Chessboard();
            chessboard.AddPiece(new King("a", ""));
        }

        [TestMethod]
        [ExpectedException(typeof(ChessBoardException), "Invalid square")]
        public void AddPieceOutsideCol()
        {
            var chessboard = new Chessboard();
            chessboard.AddPiece(new King("", "1"));
        }

        [TestMethod]
        [ExpectedException(typeof(ChessBoardException), "2 pieces same square")]
        public void AddPiece2PieceSameSquare()
        {
            var chessboard = new Chessboard();
            chessboard.AddPiece(new King("a", "1"));
            chessboard.AddPiece(new King("a", "1"));
        }
    }
}