
namespace chessboard.pieces
{
    public class Pawn : PieceBase, IPiece
    {
        public Pawn(enums.Color color = enums.Color.White) : base("", "", color) { }


        public Pawn(string collumn, string row, enums.Color color = enums.Color.White) : base(collumn, row, color) { }

        public string Name { get => "Pawn"; }

        public List<Square> AvailableMove
        {
            get
            {
                var moves = new List<Square>();

                return moves;
            }
        }
    }
}
