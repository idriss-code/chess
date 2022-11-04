
using System.Collections.Generic;

namespace chessboard.pieces
{
    public class Knight : PieceBase, IPiece
    {
        public Knight(enums.Color color = enums.Color.White) : base("", "", color) { }


        public Knight(string collumn, string row, enums.Color color = enums.Color.White) : base(collumn, row, color) { }

        public override string Name { get => "Knight"; }

        public override List<Square> AvailableMove
        {
            get
            {
                var moves = new List<Square>();

                var longs = new List<int>() { -2, 2 };
                var shorts = new List<int>() { -1, 1 };

                foreach (int l in longs)
                {
                    foreach (int s in shorts)
                    {
                        AddMove(moves, ColIndex + l, RowIndex + s);
                        AddMove(moves, ColIndex + s, RowIndex + l);
                    }
                }

                return moves;
            }
        }

        private void AddMove(List<Square> moves, int c, int r)
        {
            if (IsOnchessBoard(c, r) && IsEmptyOrOposite(c, r))
            {
                moves.Add(new Square(Chessboard.collumns[c], Chessboard.rows[r]));
            }
        }
    }
}
