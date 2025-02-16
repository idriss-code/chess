﻿
using chessboard.exceptions;
using System.Collections.ObjectModel;

namespace chessboard.pieces
{
    public abstract class PieceBase : IPiece
    {
        protected static readonly int maxMove = 7;

        public PieceBase(string collumn, string row, enums.Color color)
        {
            Row = row;
            Collumn = collumn;
            Color = color;
        }

        public abstract List<Square> AvailableMove { get; }

        public abstract string Name { get; }

        public string Row { get; private set; }
        public string Collumn { get; set; }

        public enums.Color Color { get; }

        public Chessboard? Chessboard { get; set; }

        protected int RowIndex { get => Array.IndexOf(Chessboard.rows, this.Row); }
        protected int ColIndex { get => Array.IndexOf(Chessboard.collumns, this.Collumn); }

        static protected bool IsOnchessBoard(int c, int r)
        {
            return c >= 0 && r >= 0 && c < Chessboard.collumns.Length && r < Chessboard.rows.Length;
        }

        protected bool IsNotOriginSquare(int c, int r)
        {
            return c != ColIndex || r != RowIndex;
        }

        protected bool IsEmptyOrOposite(int c, int r)
        {
            IPiece? target = Chessboard?.GetPieceOnSquare(Chessboard.collumns[c], Chessboard.rows[r]);
            if (target == null)
                return true;
            if (target.Color != this.Color)
                return true;
            return false;
        }

        protected bool IsOposite(int c, int r)
        {
            IPiece? target = Chessboard?.GetPieceOnSquare(Chessboard.collumns[c], Chessboard.rows[r]);
            if (target == null)
                return false;
            if (target.Color != this.Color)
                return true;
            return false;
        }

        protected bool IsEmpty(int c, int r)
        {
            IPiece? target = Chessboard?.GetPieceOnSquare(Chessboard.collumns[c], Chessboard.rows[r]);
            if (target == null)
                return true;
            return false;
        }

        protected bool IsKingCheckPosition(int c, int r)
        {
            string Col = Chessboard.collumns[c];
            string Row = Chessboard.rows[r];

            ReadOnlyCollection<IPiece> OpositPieces;
            if (this.Color == enums.Color.White)
            {
                OpositPieces = this.Chessboard.BlackPieces;
            }
            else
            {
                OpositPieces = this.Chessboard.WhitePieces;
            }

            foreach (IPiece piece in OpositPieces)
            {
                if (piece.AvailableMove.Contains(new Square(Col,Row)))
                {
                    return true;
                }
            }

            return false;
        }

        protected void AddColumnMove(List<Square> moves)
        {
            for (int r = RowIndex + 1; r < RowIndex + maxMove; r++)
            {
                if (!AddSquareAndCheckToContinue(moves, ColIndex, r))
                {
                    break;
                }
            }

            for (int r = RowIndex - 1; r > RowIndex - maxMove; r--)
            {
                if (!AddSquareAndCheckToContinue(moves, ColIndex, r))
                {
                    break;
                }
            }

            for (int c = ColIndex + 1; c < ColIndex + maxMove; c++)
            {
                if (!AddSquareAndCheckToContinue(moves, c, RowIndex))
                {
                    break;
                }
            }

            for (int c = ColIndex - 1; c > ColIndex - maxMove; c--)
            {
                if (!AddSquareAndCheckToContinue(moves, c, RowIndex))
                {
                    break;
                }
            }
        }

        protected void AddDiagonalMove(List<Square> moves)
        {
            for (int r = RowIndex + 1, c = ColIndex + 1; r < RowIndex + maxMove && c < ColIndex + maxMove; r++, c++)
            {
                if (!AddSquareAndCheckToContinue(moves, c, r))
                {
                    break;
                }
            }

            for (int r = RowIndex - 1, c = ColIndex + 1; r > RowIndex - maxMove && c < ColIndex + maxMove; r--, c++)
            {
                if (!AddSquareAndCheckToContinue(moves, c, r))
                {
                    break;
                }
            }

            for (int r = RowIndex + 1, c = ColIndex - 1; r < RowIndex + maxMove && c > ColIndex - maxMove; r++, c--)
            {
                if (!AddSquareAndCheckToContinue(moves, c, r))
                {
                    break;
                }
            }

            for (int r = RowIndex - 1, c = ColIndex - 1; r > RowIndex - maxMove && c > ColIndex - maxMove; r--, c--)
            {
                if (!AddSquareAndCheckToContinue(moves, c, r))
                {
                    break;
                }
            }
        }

        protected bool AddSquareAndCheckToContinue(List<Square> moves, int c, int r)
        {
            if (IsOnchessBoard(c, r))
            {
                if (IsEmptyOrOposite(c, r))
                {
                    moves.Add(new Square(Chessboard.collumns[c], Chessboard.rows[r]));
                }

                if (!IsEmpty(c, r))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

            return false;
        }

        public virtual void Move(string c, string r)
        {
            ControlPlayerValidity();

            if (this.AvailableMove.Contains(new Square(c, r)))
            {
                Capture(c, r);

                Row = r;
                Collumn = c;

                ResetAllEnPassantMove();
            }
            else
            {
                throw new ChessBoardException("Invalid move");
            }

            Chessboard?.SwitchPlayer();
        }

        protected void ControlPlayerValidity()
        {
            if (Chessboard?.CurrentPlayer != Color)
            {
                throw new ChessBoardException("Invalid Player");
            }
        }

        private void Capture(string c, string r)
        {
            var target = Chessboard?.GetPieceOnSquare(c, r);
            target?.RemoveFromChessBoard();
        }

        private void ResetAllEnPassantMove()
        {
            if (Chessboard == null)
                throw new Exception("ResetAllEnPassantMove : No Chessboard");

            foreach (Pawn pawn in Chessboard.GetAllPawnOfOneSide(this.Color))
            {
                pawn.ResetEnPassantMove();
            }
        }

        public void RemoveFromChessBoard()
        {
            Row = "";
            Collumn = "";

            Chessboard?.Remove(this);
        }
    }
}
