using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chessboard.pieces
{
    public class King : IPiece
    {


        public King(enums.Color color = enums.Color.White)
        {
            Row = "";
            Collumn = "";
            Color = color;
        }

        public King(string collumn, string row, enums.Color color = enums.Color.White)
        {
            Row = row;
            Collumn = collumn;
            Color = color;
        }


        public string Name { get => "King"; }

        public string Row { get; }
        public string Collumn { get; }

        public enums.Color Color { get; }

        public Chessboard? Chessboard { get; set;}

        private int RowIndex { get => Array.IndexOf(Chessboard.rows, this.Row); }
        private int ColIndex { get => Array.IndexOf(Chessboard.collumns, this.Collumn); }

        public List<Square> AvailableMove
        {
            get
            {
                var moves = new List<Square>();

                for (int r = RowIndex - 1; r < RowIndex + 2; r++)
                {
                    for (int c = ColIndex - 1; c < ColIndex + 2; c++)
                    {
                        if (IsNotOriginSquare(c, r) && IsOnchessBordad(c, r) && IsEmptyOrOposite(c, r))
                        {
                            moves.Add(new Square(Chessboard.collumns[c], Chessboard.rows[r]));
                        }
                    }
                }

                return moves;
            }
        }

        static private bool IsOnchessBordad(int c, int r)
        {
            return c >= 0 && r >= 0 && c < Chessboard.collumns.Length && r < Chessboard.rows.Length;
        }

        private bool IsNotOriginSquare(int c, int r)
        {
            return c != ColIndex || r != RowIndex;
        }

        private bool IsEmptyOrOposite(int c, int r)
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
