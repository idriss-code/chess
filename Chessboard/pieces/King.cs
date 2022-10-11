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
    }
}
