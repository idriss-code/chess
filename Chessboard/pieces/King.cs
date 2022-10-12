using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chessboard.pieces
{
    public class King : IPiece
    {


        public King()
        {
            Row = "";
            Collumn = "";
        }

        public King(string collumn, string row)
        {
            Row = row;
            Collumn = collumn;
        }


        public string Name { get => "King"; }

        public string Row { get; }
        public string Collumn { get; }

        public List<Square> AvailableMove { 
            get {
                var moves = new List<Square>();

                int RowIndex = Array.IndexOf(Chessboard.rows, this.Row);
                int ColIndex = Array.IndexOf(Chessboard.collumns, this.Collumn);

                for(int r = RowIndex - 1; r < RowIndex +2; r++)
                {
                    for (int c = ColIndex - 1; c < ColIndex + 2; c++)
                    {
                        if(c != ColIndex || r != RowIndex)
                        {
                            moves.Add(new Square(Chessboard.collumns[c], Chessboard.rows[r]));
                        }
                    }
                }

                return moves;
            }
        }
    }
}
