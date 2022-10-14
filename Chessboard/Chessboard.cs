using chessboard.exceptions;
using chessboard.pieces;

namespace chessboard
{
    public class Chessboard
    {
        readonly List<IPiece> pieces = new List<IPiece>();

        public static readonly string[] rows = { "1", "2", "3", "4", "5", "6", "7", "8" };
        public static readonly string[] collumns = { "a", "b", "c", "d", "e", "f", "g", "h" };

        public IPiece? GetSquare(string collumn, string row)
        {
            return pieces.Find(x => x.Row == row && x.Collumn == collumn);
        }

        public void NewGame()
        {
            this.AddPiece(new King("e", "1"));
        }

        public void AddPiece(IPiece piece)
        {
            this.CheckSquare(piece);
            pieces.Add(piece);
            piece.Chessboard = this;
        }

        private void CheckSquare(IPiece piece)
        {
            if (!Chessboard.rows.Any(x => x == piece.Row) || !Chessboard.collumns.Any(x => x == piece.Collumn))
            {
                throw new ChessBoardException("Invalid square");
            }

            if (this.GetSquare(piece.Collumn, piece.Row) != null)
            {
                throw new ChessBoardException("2 pieces same square");
            }
        }
    }
}