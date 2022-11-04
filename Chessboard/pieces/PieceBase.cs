
using chessboard.exceptions;
using System.ComponentModel.Design;

namespace chessboard.pieces
{
    public abstract class PieceBase:IPiece
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
        public string Collumn { get; private set; }

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
            IPiece? target = Chessboard?.GetSquare(Chessboard.collumns[c], Chessboard.rows[r]);
            if (target == null)
                return true;
            if (target.Color != this.Color)
                return true;
            return false;
        }

        protected bool IsOposite(int c, int r)
        {
            IPiece? target = Chessboard?.GetSquare(Chessboard.collumns[c], Chessboard.rows[r]);
            if (target == null)
                return false;
            if (target.Color != this.Color)
                return true;
            return false;
        }

        protected bool IsEmpty(int c, int r)
        {
            IPiece? target = Chessboard?.GetSquare(Chessboard.collumns[c], Chessboard.rows[r]);
            if (target == null)
                return true;
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
            if(this.AvailableMove.Contains(new Square(c, r)))
            {
                var target = Chessboard?.GetSquare(c, r);
                if (target != null)
                {
                    target.Kill();
                }
                Row = r;
                Collumn = c;
            }
            else
            {
                throw new ChessBoardException("Invalid move");
            }
        }

        public void Kill()
        {
            Row = "";
            Collumn = "";

            Chessboard?.Remove(this);
        }
    }
}
