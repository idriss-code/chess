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

        public string Row { get; }
        public string Collumn { get; }

        bool IEquatable<Square>.Equals(Square? other)
        {
            if (other is null) return false;
            return (this.Row == other.Row && this.Collumn == other.Collumn);
        }

        public static bool operator ==(Square a, Square b)
        {
            return (a.Row == b.Row && a.Collumn == b.Collumn);
        }

        // If you implement ==, you must implement !=.
        public static bool operator !=(Square a, Square b)
        {
            return !(a == b);
        }

        // Equals should be consistent with operator ==.
        public override bool Equals(Object? obj)
        {
            Square? good = obj as Square;
            if (good is null)
                return false;

            return this == good;
        }
    }
}
