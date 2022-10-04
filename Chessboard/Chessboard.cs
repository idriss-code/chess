using chessboard.pieces;

namespace chessboard
{
    public class Chessboard
    {
        List<IPiece> pieces = new List<IPiece>();

        public IPiece? GetSquare(string collumn, string row)
        {
            return pieces.Find(x => x.Row == row && x.Collumn == collumn);
        }

        public void NewGame()
        {
            pieces.Add(new King("e", "1"));
        }

    }
}