
namespace chessboard.pieces
{
    public class Bishop : PieceBase, IPiece
    {
        public Bishop(enums.Color color = enums.Color.White) : base("", "", color) { }


        public Bishop(string collumn, string row, enums.Color color = enums.Color.White) : base(collumn, row, color) { }

        public string Name { get => "Bishop"; }

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
