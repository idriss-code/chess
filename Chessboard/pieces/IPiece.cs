using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chessboard.pieces
{
    public interface IPiece
    {
        string Name { get; }

        string Row { get; }
        string Collumn { get; }
    }
}
