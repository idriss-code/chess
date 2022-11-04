
namespace chessboard.pieces
{
    // TODO special move Clasting
    public class Rook : PieceBase, IPiece
    {
        public Rook(enums.Color color = enums.Color.White) : base("", "", color) { }


        public Rook(string collumn, string row, enums.Color color = enums.Color.White) : base(collumn, row, color) { }

        public override string Name { get => "Rook"; }

        public override List<Square> AvailableMove
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
