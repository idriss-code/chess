using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chessboard.pieces
{
    public class Rook : PieceBase, IPiece
    {
        public Rook(enums.Color color = enums.Color.White) : base("", "", color) { }


        public Rook(string collumn, string row, enums.Color color = enums.Color.White) : base(collumn, row, color) { }

        public string Name { get => "Rook"; }

        public List<Square> AvailableMove
        {
            get
            {
                var moves = new List<Square>();

                for (int r = RowIndex + 1; r < RowIndex + maxMove; r++)
                {
                    if (IsNotOriginSquare(ColIndex, r) && IsOnchessBoard(ColIndex, r) && IsEmptyOrOposite(ColIndex, r))
                    {
                        moves.Add(new Square(Chessboard.collumns[ColIndex], Chessboard.rows[r]));
                    }
                }

                for (int r = RowIndex - 1; r > RowIndex - maxMove; r--)
                {
                    if (IsNotOriginSquare(ColIndex, r) && IsOnchessBoard(ColIndex, r) && IsEmptyOrOposite(ColIndex, r))
                    {
                        moves.Add(new Square(Chessboard.collumns[ColIndex], Chessboard.rows[r]));
                    }
                }

                for (int c = ColIndex + 1; c < ColIndex + maxMove; c++)
                {
                    if (IsNotOriginSquare(c, RowIndex) && IsOnchessBoard(c, RowIndex) && IsEmptyOrOposite(c, RowIndex))
                    {
                        moves.Add(new Square(Chessboard.collumns[c], Chessboard.rows[RowIndex]));
                    }
                }

                for (int c = ColIndex - 1; c > ColIndex - maxMove; c--)
                {
                    if (IsNotOriginSquare(c, RowIndex) && IsOnchessBoard(c, RowIndex) && IsEmptyOrOposite(c, RowIndex))
                    {
                        moves.Add(new Square(Chessboard.collumns[c], Chessboard.rows[RowIndex]));
                    }
                }

                return moves;
            }
        }
    }
}
