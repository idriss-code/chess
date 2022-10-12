using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chessboard
{
    public class Square : IEquatable<Square>
    {
        public Square(string collumn, string row)
        {
            Row = row;
            Collumn = collumn;
        }

        string Row { get; }
        string Collumn { get; }

        bool IEquatable<Square>.Equals(Square? other)
        {
            if (other == null) return false;
            return (this.Row == other.Row && this.Collumn == other.Collumn);
        }
    }
}
