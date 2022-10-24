
namespace chessboard.pieces
{
    public class Knight : PieceBase, IPiece
    {
        public Knight(enums.Color color = enums.Color.White) : base("", "", color) { }


        public Knight(string collumn, string row, enums.Color color = enums.Color.White) : base(collumn, row, color) { }

        public string Name { get => "Knight"; }

        public override List<Square> AvailableMove
        {
            get
            {
                var moves = new List<Square>();

                return moves;
            }
        }
    }
}
