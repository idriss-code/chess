
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

                AddColumnMove(moves);

                return moves;
            }
        }
    }
}
