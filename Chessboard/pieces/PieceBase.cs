using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chessboard.pieces
{
    public abstract class PieceBase
    {
        protected static readonly int maxMove = 7;

        public PieceBase(string collumn, string row, enums.Color color)
        {
            Row = row;
            Collumn = collumn;
            Color = color;
        }

        public string Row { get; }
        public string Collumn { get; }

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
    }
}
